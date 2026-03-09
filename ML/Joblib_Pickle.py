#save and load model joblib and pickle
import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression
from sklearn.metrics import r2_score
import pickle

# Load dataset
data = pd.read_csv("tips.csv")

print(data.head())

# Convert categorical data
data = pd.get_dummies(data, drop_first=True)

# Split features and target
X = data.drop("tip", axis=1)
y = data["tip"]

# Train-test split
X_train, X_test, y_train, y_test = train_test_split(X,y,test_size=0.2)

# Train model
model = LinearRegression()
model.fit(X_train,y_train)

# Prediction
y_pred = model.predict(X_test)

print("R2 Score:", r2_score(y_test,y_pred))

# Save model
pickle.dump(model, open("model.pkl","wb"))

# Load model
loaded_model = pickle.load(open("model.pkl","rb"))

print("Loaded Model Score:", loaded_model.score(X_test,y_test))
