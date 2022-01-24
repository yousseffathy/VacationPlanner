import json
from pathlib import Path
import requests
path = Path(__file__).parent / "temp.json"
f = open(path)
jsonData = json.load(f)
headers = {'Content-type': 'application/json'}
for i in jsonData:
    r = requests.post("https://localhost:7167/destinations", data = json.dumps(i), verify=False, headers=headers)
