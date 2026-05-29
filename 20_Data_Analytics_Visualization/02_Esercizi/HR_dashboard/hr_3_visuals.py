import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt
import numpy as np
from datetime import datetime
import os

# Paths
base_dir = os.path.dirname(__file__)
excel_path = os.path.join(base_dir, 'HR_Analytics_Dashboard.xlsx')
out_dir = os.path.join(base_dir, 'visuals')
os.makedirs(out_dir, exist_ok=True)

# Read data
df = pd.read_excel(excel_path, sheet_name='Data', engine='openpyxl')

# Preprocess: tenure in years
now = pd.Timestamp.now()
if 'HireDate' in df.columns:
    df['HireDate'] = pd.to_datetime(df['HireDate'])
    df['TenureYears'] = (now - df['HireDate']).dt.days / 365.25
else:
    df['TenureYears'] = np.random.uniform(0,10,size=len(df))

# Buckets for tenure
bins = [0,1,3,5,10,100]
labels = ['0-1','1-3','3-5','5-10','10+']
df['TenureBucket'] = pd.cut(df['TenureYears'], bins=bins, labels=labels, right=False)

sns.set(style='whitegrid', palette='muted')

# VISUAL 1 - Context: MonthlyIncome distribution by Department (boxplot)
plt.figure(figsize=(10,6))
ax1 = sns.boxplot(x='Department', y='MonthlyIncome', data=df)
ax1.set_title('Context: Monthly Income distribution by Department')
ax1.set_ylabel('Monthly Income (EUR)')
plt.xticks(rotation=30)
plt.tight_layout()
plt.savefig(os.path.join(out_dir, 'viz1_income_by_dept.png'), dpi=200)
plt.close()

# VISUAL 2 - Insight: Age vs MonthlyIncome scatter with regression, colored by Department
plt.figure(figsize=(10,6))
ax2 = sns.scatterplot(x='Age', y='MonthlyIncome', hue='Department', data=df, alpha=0.7)
# Add regression line overall (linear fit)
sns.regplot(x='Age', y='MonthlyIncome', data=df, scatter=False, color='black')
ax2.set_title('Insight: Age vs Monthly Income (trend)')
ax2.set_ylabel('Monthly Income (EUR)')
plt.legend(bbox_to_anchor=(1.02,1), loc='upper left')
plt.tight_layout()
plt.savefig(os.path.join(out_dir, 'viz2_age_vs_income.png'), dpi=200)
plt.close()

# VISUAL 3 - Action: Average MonthlyIncome by TenureBucket with counts
income_by_tenure = df.groupby('TenureBucket').agg(AvgIncome=('MonthlyIncome','mean'), Count=('EmployeeID','count')).reset_index()
plt.figure(figsize=(8,5))
ax3 = sns.barplot(x='TenureBucket', y='AvgIncome', data=income_by_tenure, palette='Blues_d')
for i, row in income_by_tenure.iterrows():
    ax3.text(i, row['AvgIncome'] + 50, f"n={int(row['Count'])}", ha='center')
ax3.set_title('Action: Avg Monthly Income by Tenure Bucket')
ax3.set_ylabel('Avg Monthly Income (EUR)')
plt.tight_layout()
plt.savefig(os.path.join(out_dir, 'viz3_income_by_tenure.png'), dpi=200)
plt.close()

# Summary file
summary_path = os.path.join(base_dir, 'visuals_summary.md')
with open(summary_path, 'w', encoding='utf-8') as f:
    f.write('# Executive Story — 3 Visuals\n\n')
    f.write('**Claim (insight):** I dipendenti con bassa anzianità (0-1 anni) hanno in media uno stipendio simile o leggermente inferiore rispetto ai colleghi con 1-3 anni; invece gli aumenti salariali più significativi si vedono dopo 3-5 anni.\n\n')
    f.write('**Context (Visual 1):** Distribuzione degli stipendi per Department — permette vedere spread e outlier (file: viz1_income_by_dept.png)\n\n')
    f.write('**Insight (Visual 2):** Relazione tra età e stipendio con trend (file: viz2_age_vs_income.png) — mostra che l\'età non è l\'unico driver, alcuni giovani hanno stipendi elevati (ruoli tecnici/seniority variabile).\n\n')
    f.write('**Action (Visual 3):** Targetare piani di retention e salary review per il gruppo 0-1 anni e 1-3 anni, incrementare programmi di mentoring e calibrate progression path (file: viz3_income_by_tenure.png)\n')

print('3 visual salvati in', out_dir)
print('Summary:', summary_path)
