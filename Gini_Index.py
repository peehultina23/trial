import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.tree import DecisionTreeClassifier
from sklearn.metrics import accuracy_score
from sklearn import tree
from sklearn.model_selection import train_test_split
from sklearn.datasets import load_iris

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
clf = DecisionTreeClassifier(criterion="entropy", random_state=42)
clf.fit(X_train, y_train)
y_pred = clf.predict(X_test)
accuracy = accuracy_score(y_test, y_pred)
print(f"Accuracy: {accuracy:.2f}")
print()
tree.plot_tree(clf, filled=True)
plt.title("Decision Tree for Iris Dataset")
plt.show()