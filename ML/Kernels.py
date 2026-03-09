#linear kernel
import numpy as np
import matplotlib.pyplot as plt
from sklearn.datasets import load_iris
from sklearn.svm import SVC
# Load iris dataset
iris = load_iris()
X = iris.data[:, :2]  # Use only the first two features for visualization
y = iris.target

# Train SVM with linear kernel
model_linear = SVC(kernel='linear', C=1)
model_linear.fit(X, y)

#polynomial kernel
model_poly = SVC(kernel='poly', degree=3, C=1)
model_poly.fit(X, y)

#rbf kernel
model_rbf = SVC(kernel='rbf', gamma='scale', C=1)
model_rbf.fit(X, y)

#metrics
from sklearn.metrics import classification_report, confusion_matrix
y_pred_linear = model_linear.predict(X)
y_pred_poly = model_poly.predict(X)
y_pred_rbf = model_rbf.predict(X)
print("Linear Kernel Classification Report:\n", classification_report(y, y_pred_linear))
print("Polynomial Kernel Classification Report:\n", classification_report(y, y_pred_poly))
print("RBF Kernel Classification Report:\n", classification_report(y, y_pred_rbf))
print("Linear Kernel Confusion Matrix:\n", confusion_matrix(y, y_pred_linear))
print("Polynomial Kernel Confusion Matrix:\n", confusion_matrix(y, y_pred_poly))
print("RBF Kernel Confusion Matrix:\n", confusion_matrix(y, y_pred_rbf))

