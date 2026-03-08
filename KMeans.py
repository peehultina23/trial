#to generate random 150 samples.
from sklearn.datasets import make_blobs
x,y =make_blobs(n_samples = 150, n_features =2, centers=3, random_state =0)
print(x)
print(y)

#to visualize the data
import matplotlib.pyplot as plt
plt.scatter(x[:,0], x[:,1], c=y)
plt.grid()
plt.show()

#to apply kmeans clustering
from sklearn.cluster import KMeans
kmeans = KMeans(n_clusters=3)
kmeans.fit(x)

#to get the cluster centers
print(kmeans.cluster_centers_)

#to get the labels of each point
print(kmeans.labels_)

#to visualize the clusters
plt.scatter(x[:,0], x[:,1], c=kmeans.labels_)
plt.scatter(kmeans.cluster_centers_[:,0], kmeans.cluster_centers_[:,1], c='red', marker='X')
plt.grid()
plt.show()






