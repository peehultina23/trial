import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.datasets import load_iris
from sklearn.ensemble import RandomForestClassifier, RandomForestRegressor
from sklearn.metrics import (accuracy_score, classification_report, confusion_matrix, mean_absolute_error, mean_squared_error)

# Load iris dataset
iris = load_iris()
df = pd.DataFrame(iris.data,columns=iris.feature_names)
df['species'] = iris.target
df['species'] = df['species'].map({i: name for i, name in enumerate(iris.target_names)})

# View data
print(df.head())
print(df['species'].value_counts())

# Visualization: Sepal length vs Sepal width
sns.FacetGrid(df, hue="species", height=6).map(plt.scatter, "sepal length (cm)", "sepal width (cm)").add_legend()
plt.show()

# Features and target
X = df[['sepal length (cm)', 'sepal width (cm)']]
y = df['species']

# Train-test split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Classification with RandomForest
classifier = RandomForestClassifier(n_estimators=20, random_state=42)
classifier.fit(X_train, y_train)
y_pred_class = classifier.predict(X_test)
print("\n Classification Results")
print("Accuracy:", accuracy_score(y_test, y_pred_class))
print("Classification Report:\n", classification_report(y_test, y_pred_class))
print("Confusion Matrix:\n", confusion_matrix(y_test, y_pred_class))

# Regression with RandomForest
# Encode species labels numerically for regression
y_numeric = pd.factorize(y)[0]
X_train_r, X_test_r, y_train_r, y_test_r = train_test_split(X, y_numeric, test_size=0.2, random_state=42)
regressor = RandomForestRegressor(n_estimators=20, random_state=42)
regressor.fit(X_train_r, y_train_r)
y_pred_reg = regressor.predict(X_test_r)
print("\n Regression Results")
print("Mean Absolute Error:", mean_absolute_error(y_test_r, y_pred_reg))
print("Mean Squared Error:", mean_squared_error(y_test_r, y_pred_reg))
print("Root Mean Squared Error:", np.sqrt(mean_squared_error(y_test_r,
y_pred_reg)))

#Petrol_consumption dataset
import os
os.getlogin()
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestClassifier, RandomForestRegressor
from sklearn.metrics import (accuracy_score, classification_report, confusion_matrix,mean_absolute_error, mean_squared_error)

#read csv
dataset = pd.read_csv(rf"C:\Users\{os.getlogin()}\Downloads\petrol_consumption.csv")
print(dataset.head())
print(dataset.info())
print(dataset.describe())
print(dataset.isnull().sum())

# Visualization
sns.pairplot(dataset)
plt.show()

# Features and target
X = dataset[['Petrol_tax', 'Average_income', 'Paved_Highways','Population_Driver_licence(%)']]
y = dataset['Petrol_Consumption']

# Train-test split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Regression with RandomForest
regressor = RandomForestRegressor(n_estimators=100, random_state=42)
regressor.fit(X_train, y_train)
y_pred = regressor.predict(X_test)
print("\n Regression Results")
print("Mean Absolute Error:", mean_absolute_error(y_test, y_pred))
print("Mean Squared Error:", mean_squared_error(y_test, y_pred))
print("Root Mean Squared Error:", np.sqrt(mean_squared_error(y_test, y_pred)))

# Classification with RandomForest
# For classification, we need to create a categorical target variable
# Let's categorize Petrol_Consumption into 'Low', 'Medium', 'High'
y_class = pd.cut(y, bins=3, labels=['Low', 'Medium', 'High'])
X_train_c, X_test_c, y_train_c, y_test_c = train_test_split(X, y_class, test_size=0.2, random_state=42)
classifier = RandomForestClassifier(n_estimators=100, random_state=42)
classifier.fit(X_train_c, y_train_c)
y_pred_class = classifier.predict(X_test_c)
print("\n Classification Results")
print("Accuracy:", accuracy_score(y_test_c, y_pred_class))
print("Classification Report:\n", classification_report(y_test_c, y_pred_class))
print("Confusion Matrix:\n", confusion_matrix(y_test_c, y_pred_class))