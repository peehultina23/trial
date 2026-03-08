import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn import datasets
from sklearn import metrics
from sklearn.neighbors import KNeighborsClassifier

iris = datasets.load_iris()
iris_data=datasets.load_iris()
print(iris_data.DESCR)

# Create a DataFrame
iris_df = pd.DataFrame(np.c_[iris['data'], iris['target']],
columns = iris['feature_names'] + ['target'])
print(iris_df)

sns.FacetGrid(iris_df, hue="target", height=5).map(plt.scatter, 'petal length (cm)', 'petal width (cm)').add_legend()
plt.show()

model = KNeighborsClassifier(n_neighbors=3)
model.fit(iris.data, iris.target)
print("Model trained successfully.")
predicted = model.predict(iris.data)
expected = iris.target
print("Predictions made successfully.")
model_score = model.score(iris.data, iris.target)
print("Model Score:", model_score)
print(metrics.classification_report(expected, predicted,
target_names=iris.target_names))
print(metrics.confusion_matrix(expected, predicted))