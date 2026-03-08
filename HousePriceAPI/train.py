import pandas as pd
from sklearn.linear_model import LinearRegression
import joblib

data = pd.read_csv("C:\\Users\\Peehul\\trial\\HousePriceAPI\\house_price.csv")
X = data[['SquareFeet','Bedrooms']]
y = data['Price']
model = LinearRegression()
model.fit(X, y)
joblib.dump(model, "model.pkl")
print("Model trained and saved")