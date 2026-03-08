import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler
from sklearn import metrics
from sklearn.datasets import load_iris
from sklearn.linear_model import LogisticRegression

# Load iris dataset
data = load_iris()

# Create DataFrame for inspection (optional)
df = pd.DataFrame(data.data, columns=data.feature_names)
df['Species'] = data.target
print(df.head())

# Features (X) and target (y)
X = data.data
y = data.target

# Split dataset
X_train, X_test, y_train, y_test = train_test_split(
    X, y, test_size=0.2, random_state=42
)

# Train logistic regression model
model = LogisticRegression(max_iter=200)
model.fit(X_train, y_train)

# Model parameters
print("Intercept:", model.intercept_)
print("Coefficients:", model.coef_)

# Accuracy on test set
print("Test Accuracy:", model.score(X_test, y_test))

# Predictions
predicted = model.predict(X_test)
expected = y_test

# Evaluation
print("Accuracy:", metrics.accuracy_score(expected, predicted))
print("\nClassification Report:\n", metrics.classification_report(expected, predicted, target_names=data.target_names))
print("Confusion Matrix:\n", metrics.confusion_matrix(expected, predicted))