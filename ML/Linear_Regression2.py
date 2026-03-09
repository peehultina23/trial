Practical 4 - Linear Regression

import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn import metrics

# Load dataset
df_sal = pd.read_csv('Salary_Data.csv')

# Preview first 11 records
print(df_sal.head(11))

df_sal.describe()
 
#Scatter plot
plt.scatter(df_sal['YearsExperience'],df_sal['Salary'])
plt.xlabel('Years of Experience')
plt.ylabel('Salary')
plt.show()

x = df_sal.iloc[:,:1]
print(x)
y=df_sal.iloc[:,1:]
print(y)

x_train, x_test, y_train, y_test = train_test_split(x, y, train_size=0.2, random_state=0)
print(x_train)
print()
print(x_test)
print()
print(y_train)
print()
print(y_test)
print()
       
# Create and train the model
regressor = LinearRegression()
regressor.fit(x_train, y_train)

# Print coefficient and intercept
print(f'Coefficient: {regressor.coef_}')
print(f'Intercept: {regressor.intercept_}')

# Predictions
y_pred_train = regressor.predict(x_train)

# Training plot
plt.scatter(x_train, y_train, color='lightcoral')
plt.plot(x_train, y_pred_train, color='firebrick')
plt.title('Salary vs Experience (Training Set)')
plt.xlabel('Years of Experience')
plt.ylabel('Salary')
plt.legend(['Predicted (Train)','Actual (Train)'], title='Sal/Exp', loc='best', facecolor='white')
plt.box(False)
plt.show()

# Training R²
train_error_score = metrics.r2_score(y_train, y_pred_train)
print("R Squared error - Training: ", train_error_score)

y_pred_test = regressor.predict(x_test)
# Test plot
plt.scatter(x_test, y_test, color='lightcoral')
plt.plot(x_test, y_pred_test, color='firebrick')
plt.title('Salary vs Experience (Test Set)')
plt.xlabel('Years of Experience')
plt.ylabel('Salary')
plt.legend(['Predicted (Test)','Actual (Test)'], title='Sal/Exp', loc='best', facecolor='white')
plt.box(False)
plt.show()

# Test R²
test_error_score = metrics.r2_score(y_test, y_pred_test)
print("R Squared error - Testing: ", test_error_score)