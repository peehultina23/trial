import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt

#dataframe
data = {"Name": ["Alice", "NA", None, "David", "Eve"],
        "Age": [25, 30, 35, 40, 'missing']}
df = pd.DataFrame(data)

# Display the DataFrame
print(df)
# Summary statistics
print(df.describe())

#cleaning data
# Check for missing values
df.replace("NA", np.nan, inplace=True)
df.replace("missing", np.nan, inplace=True)

df['Age'] = df['Age'].astype(float)
# Fill missing values with the mean age
mean_age = df['Age'].mean()
print(df)
print(df.describe())

# Visualization
plt.hist(df['Age'], bins=5, edgecolor='black')
plt.title('Age Distribution')
plt.xlabel('Age')
plt.ylabel('Frequency')
plt.show()

sns.boxplot(x=df['Age'])
plt.title('Boxplot of Age') 
plt.show()



