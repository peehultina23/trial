#Load DataSet and Libraries
from sklearn import datasets
from sklearn import metrics
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
#%matplotlib inline
import seaborn as sns
from sklearn.naive_bayes import GaussianNB

# Load the iris dataset
iris = datasets.load_iris()
df = pd.DataFrame(data = np.c_[iris['data'], iris['target']], columns= iris
['feature_names'] + ['target'])
print(df.head())

# Visualizing the dataset
sns.pairplot(df, hue="target", height=3)
plt.show()

#model Gaussian Naive Bayes
model = GaussianNB()
model.fit(iris.data, iris.target)
print("Model Accuracy:", model.score(iris.data, iris.target))
expected = iris.target
predicted = model.predict(iris.data)
print(metrics.classification_report(expected, predicted))
print(metrics.confusion_matrix(expected, predicted))

#B part
from sklearn.naive_bayes import MultinomialNB
model = MultinomialNB()
model.fit(iris.data, iris.target)
expected = iris.target
predicted = model.predict(iris.data)
print(metrics.classification_report(expected, predicted))
print(metrics.confusion_matrix(expected, predicted))
print("Model Accuracy:", model.score(iris.data, iris.target))

#Cpart bernoulli
from sklearn.naive_bayes import BernoulliNB
model = BernoulliNB()
model.fit(iris.data, iris.target)
expected = iris.target
predicted = model.predict(iris.data)
print(metrics.classification_report(expected, predicted))
print(metrics.confusion_matrix(expected, predicted))
print("Model Accuracy:", model.score(iris.data, iris.target))