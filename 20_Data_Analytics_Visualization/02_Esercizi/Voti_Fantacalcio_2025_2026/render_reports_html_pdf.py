from pathlib import Path
import re
import sys

CSS = '''
body { font-family: Inter, Arial, sans-serif; margin: 28px; color: #222; }
header { text-align: center; margin-bottom: 24px; }
h1 { color: #0b5ed7; }
h2 { color: #0a66c2; }
article { max-width: 900px; margin: auto; }
pre, code { background: #f6f8fa; padding: 6px 8px; border-radius: 4px; }
table { border-collapse: collapse; width: 100%; margin: 12px 0; }
th, td { border: 1px solid #ddd; padding: 8px; }
th { background: #f1f5fb; text-align: left; }
.footer { font-size: 0.9em; color: #666; margin-top: 28px; text-align: center; }
'''


def md_to_html(md_text: str, title: str = '') -> str:
    try:
        import markdown
    except Exception:
        raise

    html_body = markdown.markdown(md_text, extensions=["extra", "tables"])
    html = f"""
    <!doctype html>
    <html>
    <head>
      <meta charset="utf-8" />
      <meta name="viewport" content="width=device-width,initial-scale=1" />
      <title>{title}</title>
      <style>{CSS}</style>
    </head>
    <body>
      <article>
        <header>
          <h1>{title}</h1>
        </header>
        {html_body}
        <div class="footer">Generato con script HTML+CSS — Fantacalcio</div>
      </article>
    </body>
    </html>
    """
    return html


def rewrite_image_paths(md_text: str, md_path: Path) -> str:
    def replace(match: re.Match[str]) -> str:
        alt_text = match.group(1)
        image_path = match.group(2).strip()
        if image_path.startswith("http://") or image_path.startswith("https://"):
            return match.group(0)
        resolved = (md_path.parent / image_path).resolve()
        return f"![{alt_text}]({resolved.as_uri()})"

    return re.sub(r"!\[([^\]]*)\]\(([^)]+)\)", replace, md_text)


def render(md_path: Path):
    md_text = md_path.read_text(encoding='utf-8')
    md_text = rewrite_image_paths(md_text, md_path)
    title = md_path.stem.replace('_', ' ').capitalize()
    html = md_to_html(md_text, title=title)

    out_html = md_path.with_suffix('.html')
    out_pdf = md_path.with_suffix('.pdf')

    out_html.write_text(html, encoding='utf-8')
    print(f'HTML scritto: {out_html}')

    # Try WeasyPrint first
    try:
        from weasyprint import HTML
        HTML(string=html, base_url=md_path.parent.as_uri()).write_pdf(str(out_pdf))
        print(f'PDF scritto con WeasyPrint: {out_pdf}')
        return True
    except Exception as e:
        print('WeasyPrint fallito:', e)

    # Fallback a pdfkit (richiede wkhtmltopdf)
    try:
        import pdfkit
        pdfkit.from_string(html, str(out_pdf), options={"enable-local-file-access": ""})
        print(f'PDF scritto con pdfkit: {out_pdf}')
        return True
    except Exception as e:
        print('pdfkit fallito:', e)

    # Last-resort: ReportLab plain text (loses styling)
    try:
        from reportlab.lib.pagesizes import A4
        from reportlab.pdfgen import canvas
        from reportlab.lib.units import mm

        c = canvas.Canvas(str(out_pdf), pagesize=A4)
        w, h = A4
        margin = 20 * mm
        text = c.beginText(margin, h - margin)
        text.setFont('Helvetica', 10)
        for line in md_text.splitlines():
            text.textLine(line[:200])
            if text.getY() < margin:
                c.drawText(text)
                c.showPage()
                text = c.beginText(margin, h - margin)
                text.setFont('Helvetica', 10)
        c.drawText(text)
        c.save()
        print(f'PDF scritto con ReportLab (fallback): {out_pdf}')
        return True
    except Exception as e:
        print('ReportLab fallback fallito:', e)

    return False


def main():
    base = Path(__file__).parent
    targets = [
        base / 'report_analisi.md',
        base / 'report_processo.md',
        base / 'report_analisi_home.md',
        base / 'report_analisi_away.md',
    ]

    any_failed = False
    for md in targets:
        if not md.exists():
            print('File mancante, salto:', md)
            any_failed = True
            continue
        ok = render(md)
        if not ok:
            any_failed = True

    if any_failed:
        print('Alcuni file non sono stati convertiti correttamente.')
        sys.exit(2)
    print('Tutti i PDF sono stati rigenerati (se possibile).')


if __name__ == '__main__':
    main()
