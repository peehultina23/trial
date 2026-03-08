from flask import Flask, request, jsonify
import joblib
app = Flask(__name__)
model = joblib.load("model.pkl")
@app.route("/")
def home():
    return "House Price Prediction API Running"
@app.route("/predict", methods=["POST"])
def predict():
    data = request.json
    price = model.predict([[data['SquareFeet'], data['Bedrooms']]])
    return jsonify({"Predicted Price": float(price[0])})
if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)