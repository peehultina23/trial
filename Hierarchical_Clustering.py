#hierarchical clustering
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

#to apply hierarchical clustering
from sklearn.cluster import AgglomerativeClustering
hierarchical = AgglomerativeClustering(n_clusters=3)
hierarchical.fit(x)

#to get the labels of each point
print(hierarchical.labels_)

#to visualize the clusters
plt.scatter(x[:,0], x[:,1], c=hierarchical.labels_)
plt.grid()
plt.show()

#to create a dendrogram
from scipy.cluster.hierarchy import dendrogram, linkage
labelList = range(1, 151)

#multiple dendogram
methods = ['single', 'complete', 'average', 'ward']
for method in methods:
    linked = linkage(x, method=method)
    plt.figure(figsize=(10, 7))
    dendrogram(linked, labels=labelList)
    plt.title(f'Dendrogram ({method.capitalize()} Linkage)')
    plt.xlabel('Sample Index')
    plt.ylabel('Distance')
    plt.show()

#whats the difference between kmeans and hierarchical clustering?
#KMeans is a centroid-based clustering algorithm that partitions the data into k clusters by minimizing the within-cluster sum of squares. It iteratively assigns data points to the nearest cluster center and updates the cluster centers until convergence.
#Hierarchical clustering, on the other hand, builds a hierarchy of clusters by either merging smaller clusters (agglomerative) or splitting larger clusters (divisive). It does not require a predefined number of clusters and can produce a dendrogram to visualize the cluster hierarchy. The choice between the two depends on the specific use case and the nature of the data. 

