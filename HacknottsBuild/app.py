from flask import Flask, request
from twilio.twiml.messaging_response import MessagingResponse

outputdir = "output.txt"

app = Flask(__name__)

@app.route("/", methods=['GET', 'POST'])
def sms_ahoy_reply():
    """Respond to incoming messages with a friendly SMS."""
    # Start our response
    resp = MessagingResponse()

    data = open(outputdir, 'w')

    body = str(request.values.get('Body', None))
    sender = str(request.values.get('From', None))
    
    data.write(sender + " SENDS " + body + "\n")

    # Add a message
    print(str(sender + " SENDS '" + body + "'"))
    
    data.close()

    return str(resp)


if __name__ == "__main__":
    app.run(debug=True)