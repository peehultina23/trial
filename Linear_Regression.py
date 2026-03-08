import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split, cross_val_score
from sklearn.metrics import mean_squared_error, r2_score
import warnings
from sklearn.exceptions import UndefinedMetricWarning

# Suppress warnings for tiny test sets
warnings.filterwarnings("ignore", category=UndefinedMetricWarning)

# Load the data
data = {'Name': ['Alice', 'Bob', 'Charlie', 'David', 'Eve'],
        'Age': [25, 30, 35, 40, 45],
        'Salary': [50000, 60000, 70000, 80000, 90000]}
df = pd.DataFrame(data)
print("Original DataFrame:")
print(df)

# Prepare the data
X = df['Age'].values.reshape(-1, 1)
y = df['Salary'].values
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.4, random_state=42)

# Train model
model = LinearRegression()
model.fit(X_train, y_train)

# Predictions
predictions = model.predict(X_test)
print("\nPredicted Salaries:", predictions)

# Plot regression line across full dataset
plt.scatter(X, y, color='blue', label='Actual Salaries')
plt.plot(X, model.predict(X), color='red', label='Regression Line')
plt.title('Age vs Salary')
plt.xlabel('Age')
plt.ylabel('Salary')
plt.legend()
plt.show()

# Evaluation
mse = mean_squared_error(y_test, predictions)
r2 = r2_score(y_test, predictions)
print("\nMean Squared Error:", mse)
print("R^2 Score:", r2)

# Cross-validation for robustness
scores = cross_val_score(model, X, y, cv=3, scoring='r2')
print("Cross-validated R^2:", scores.mean())

# Coefficients
print("\nCoefficient:", model.coef_)
print("Intercept:", model.intercept_)