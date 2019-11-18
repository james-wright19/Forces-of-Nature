from twilio.rest import Client

import os
from os import path

import sched, time

account_sid = 'AC578a4f4f9e20c6bbccc15a3a753fc4a9'
auth_token = '947f379bd641dd1983306bf7816e8dc7'
client = Client(account_sid, auth_token)

inputdir = "input.txt"

s = sched.scheduler(time.time, time.sleep)

def forwardto(sc):
    if (path.exists(inputdir)):
        # Send message in input file
        f = open(inputdir, 'r')
        data = f.read()

        x = data.split("FORWARDTO")
        x2 = x[1].split("\n")

        print(x[0] + "  " + x[1])

        for num in x2:
            if num != '':
                message = client.messages.create(body=x[0],from_='whatsapp:+14155238886',to=num)
                print(message.sid)

        f.close()

        os.remove(inputdir)

    s.enter(0.5, 1, forwardto, (sc,))


if __name__== "__main__":
    s.enter(0.5, 1, forwardto, (s,))
    s.run()