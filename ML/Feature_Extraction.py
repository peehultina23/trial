import pandas as pd
import numpy as np
import pandas as pd
from sklearn.datasets import load_iris
import matplotlib.pyplot as plt
import seaborn as sns

#load the data
data = {'A': [1, 2, 3, 4, 5],
        'B': [5, 4, 3, 2, 1],
        'C': [2, 3, 4, 5, 6]}
df = pd.DataFrame(data)
print("Original DataFrame:")
print(df)

corr_matrix = df.corr()
print("\nCorrelation Matrix:")
print(corr_matrix)

upper = corr_matrix.where(np.triu(np.ones(corr_matrix.shape), k=1).astype(bool))
to_drop = [column for column in upper.columns if any(upper[column] > 0.8)]
print("\nColumns to drop due to high correlation:")
print(to_drop)

df_reduced = df.drop(columns=to_drop)
print("\nDataFrame after dropping highly correlated columns:")
print(df_reduced)

df_reduced.to_csv('reduced_data.csv', index=False)
df_new = pd.read_csv('reduced_data.csv')
print("\nDataFrame read from 'reduced_data.csv':")
print(df_new)

data = load_iris()
X = data.data
y = data.target
print("\nIris dataset features:")
print(X)
print("\nIris dataset target:")
print(y)

df=pd.DataFrame(X, columns=data.feature_names)
print("\nDataFrame created from Iris dataset:")
print(df)

plt.figure(figsize=(10, 6))
sns.heatmap(df.corr(), annot=True, cmap='coolwarm') 
plt.title('Correlation Matrix of Iris Dataset')
plt.show()

