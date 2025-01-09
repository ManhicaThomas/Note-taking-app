import sys
print("Python Path:", sys.path)
from flask import Flask

app = Flask(__name__)
app.config.from_object('config')

from app import routes

