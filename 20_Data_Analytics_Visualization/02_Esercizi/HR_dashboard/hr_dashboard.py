import pandas as pd
import numpy as np
from datetime import datetime, timedelta

# Parameters
N = 500
np.random.seed(42)

departments = ['Sales', 'Research & Development', 'Human Resources', 'IT', 'Finance']
genders = ['Male', 'Female']
jobroles = ['Sales Executive', 'Research Scientist', 'Laboratory Technician', 'Manager', 'Sales Representative', 'Research Director', 'Human Resources', 'IT Support']

# Generate synthetic dataset
ids = np.arange(1, N+1)
dep = np.random.choice(departments, size=N, p=[0.25, 0.35, 0.1, 0.2, 0.1])
job = np.random.choice(jobroles, size=N)
gender = np.random.choice(genders, size=N, p=[0.55, 0.45])
age = np.random.randint(22, 60, size=N)
monthly_income = np.round(np.random.normal(4000, 1200, size=N)).astype(int)
overtime = np.random.choice(['Yes', 'No'], size=N, p=[0.18, 0.82])
# Attrition correlated with overtime and younger employees
attrition_prob = 0.05 + (overtime == 'Yes')*0.10 + (age < 30)*0.03
attrition = np.where(np.random.rand(N) < attrition_prob, 'Yes', 'No')

hire_date = [datetime.now() - timedelta(days=int(x)) for x in np.random.exponential(365*5, size=N)]

df = pd.DataFrame({
    'EmployeeID': ids,
    'Department': dep,
    'JobRole': job,
    'Gender': gender,
    'Age': age,
    'MonthlyIncome': monthly_income,
    'OverTime': overtime,
    'Attrition': attrition,
    'HireDate': hire_date
})

# KPI calculations
df['AttritionNum'] = (df['Attrition'] == 'Yes').astype(int)

overall_attrition_rate = df['AttritionNum'].mean()
by_dept = df.groupby('Department').agg(Total=('EmployeeID','count'), Attrition=('AttritionNum','sum'))
by_dept['AttritionPct'] = by_dept['Attrition'] / by_dept['Total']

by_gender = df.groupby('Gender').agg(Total=('EmployeeID','count'), Attrition=('AttritionNum','sum'))
by_gender['AttritionPct'] = by_gender['Attrition'] / by_gender['Total']

avg_monthly_income = df['MonthlyIncome'].mean()
avg_age = df['Age'].mean()
percent_overtime = (df['OverTime'] == 'Yes').mean()

# Top-5 JobRole by attrition rate
by_job = df.groupby('JobRole').agg(Total=('EmployeeID','count'), Attrition=('AttritionNum','sum'))
by_job['AttritionPct'] = by_job['Attrition'] / by_job['Total']
top5_job = by_job.sort_values('AttritionPct', ascending=False).head(5).reset_index()

# Simulate monthly attrition last 12 months
months = pd.date_range(end=datetime.now(), periods=12, freq='ME')
monthly_attrition = pd.Series(np.random.poisson(lam=5, size=12), index=months)

# Save to Excel with charts using XlsxWriter
out_path = 'HR_Analytics_Dashboard.xlsx'
with pd.ExcelWriter(out_path, engine='xlsxwriter', datetime_format='yyyy-mm-dd') as writer:
    df.to_excel(writer, sheet_name='Data', index=False)
    # Summary data
    summary = pd.DataFrame({
        'KPI': ['Overall Attrition Rate', 'Average Monthly Income', 'Average Age', '% OverTime'],
        'Value': [overall_attrition_rate, avg_monthly_income, avg_age, percent_overtime]
    })
    summary.to_excel(writer, sheet_name='Dashboard', index=False, startrow=0)

    # Dept table
    by_dept_reset = by_dept.reset_index()
    by_dept_reset.to_excel(writer, sheet_name='Dashboard', index=False, startrow=6)

    # Top5 job
    top5_job.to_excel(writer, sheet_name='Dashboard', index=False, startrow=20)

    # Monthly attrition
    monthly_attrition.to_frame(name='Attritions').to_excel(writer, sheet_name='Dashboard', startrow=28)

    workbook = writer.book
    worksheet = writer.sheets['Dashboard']

    # Formats
    kpi_format = workbook.add_format({'font_size':14, 'bold':True})
    pct_format = workbook.add_format({'num_format':'0.00%','font_size':12})
    money_format = workbook.add_format({'num_format':'#,##0','font_size':12})

    # Write KPI values nicely
    worksheet.write('B1', overall_attrition_rate, pct_format)
    worksheet.write('B2', avg_monthly_income, money_format)
    worksheet.write('B3', avg_age)
    worksheet.write('B4', percent_overtime, pct_format)

    # Create bar chart for attrition % by Department
    chart1 = workbook.add_chart({'type':'column'})
    # by_dept is written starting at row 7 (0-indexed 6). Find ranges
    start_row = 6
    n_rows = len(by_dept_reset)
    chart1.add_series({
        'name':'Attrition % by Department',
        'categories':['Dashboard', start_row, 0, start_row + n_rows -1, 0],
        'values':['Dashboard', start_row, 3, start_row + n_rows -1, 3],
    })
    chart1.set_title({'name':'Attrition % by Department'})
    chart1.set_y_axis({'num_format':'0.0%','max':1})
    worksheet.insert_chart('G2', chart1, {'x_scale':1.2, 'y_scale':1.2})

    # Line chart for monthly attrition (sparkline-like)
    chart2 = workbook.add_chart({'type':'line'})
    chart2.add_series({
        'name':'Monthly Attritions',
        'categories':['Dashboard', 28, 0, 28+11, 0],
        'values':['Dashboard', 28, 1, 28+11, 1],
    })
    chart2.set_title({'name':'Monthly Attritions (last 12 months)'})
    worksheet.insert_chart('G16', chart2, {'x_scale':1.2, 'y_scale':1.2})

    # Table for top5 job
    chart3 = workbook.add_chart({'type':'column'})
    chart3.add_series({
        'name':'Attrition % by JobRole (Top5)',
        'categories':['Dashboard', 20, 0, 20+len(top5_job)-1, 0],
        'values':['Dashboard', 20, 3, 20+len(top5_job)-1, 3],
    })
    chart3.set_title({'name':'Top-5 JobRole by Attrition %'})
    worksheet.insert_chart('G32', chart3, {'x_scale':1.1, 'y_scale':1.1})

    # Conditional formatting: highlight dept with Attrition% > 15%
    worksheet.conditional_format(start_row, 3, start_row + n_rows -1, 3, {'type':'cell', 'criteria':'>', 'value':0.15, 'format':workbook.add_format({'bg_color':'#FFC7CE'})})

print('Dashboard saved to', out_path)
