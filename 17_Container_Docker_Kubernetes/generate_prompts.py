import os
from pathlib import Path

ROOT = Path(__file__).resolve().parent
LABS = ROOT / 'labs'
TEMPLATE = ROOT / 'TEMPLATE_PROMPT.md'


def slug_to_title(slug: str) -> str:
    s = slug
    # Remove leading numbers and dash
    s = s.split('-', 1)[-1] if '-' in s else s
    s = s.replace('_', ' ').replace('-', ' ')
    return s.capitalize()


def load_template() -> str:
    if not TEMPLATE.exists():
        raise FileNotFoundError(f"Template not found: {TEMPLATE}")
    return TEMPLATE.read_text(encoding='utf-8')


def build_prompt(subpath: Path, template_text: str) -> str:
    rel = subpath.relative_to(ROOT)
    title = slug_to_title(subpath.name)
    prompt = []
    prompt.append(f"# Prompt — {title}")
    prompt.append("")
    prompt.append(f"Contesto: `{rel}`")
    prompt.append("")
    prompt.append("Obiettivo: Dockerfile, docker-compose.yml o manifest Kubernetes e istruzioni per deploy locale.")
    prompt.append("")
    prompt.append("Richiedo: file di configurazione e i comandi `docker`/`docker compose`/`kubectl` necessari per l'avvio.")
    prompt.append("")
    prompt.append("---")
    prompt.append("")
    prompt.append("(Template sorgente: `TEMPLATE_PROMPT.md`)")
    prompt_text = '\n'.join(prompt)
    return prompt_text


def main(dry_run=False):
    template_text = load_template()
    created = []
    for entry in sorted(LABS.iterdir()):
        if not entry.is_dir():
            continue
        target = entry / 'PROMPT.md'
        if target.exists():
            continue
        content = build_prompt(entry, template_text)
        if dry_run:
            print(f"Would create: {target}")
        else:
            target.write_text(content, encoding='utf-8')
            created.append(str(target))
    if created:
        print('Created prompts:\n' + '\n'.join(created))
    else:
        print('No new prompts created.')


if __name__ == '__main__':
    import argparse
    p = argparse.ArgumentParser(description='Generate PROMPT.md files for labs')
    p.add_argument('--dry-run', action='store_true')
    args = p.parse_args()
    main(dry_run=args.dry_run)
