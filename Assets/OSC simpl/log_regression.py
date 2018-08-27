
# coding: utf-8

# In[10]:


import pandas as pd
from sklearn import cross_validation, datasets, linear_model, metrics
import OSC

#Read the csv and remove duplicates
frame = pd.read_csv("musedata1.csv", header=0, sep=',')
frame = frame.drop_duplicates()
#Form dataframe
frame.data=frame.drop(['state'],axis=1)
frame.target=frame[['state']]

train_data, test_data, train_labels, test_labels = cross_validation.train_test_split(frame.data, frame.target, test_size=0.3)

log_regressor = linear_model.LogisticRegression(random_state=1)
log_regressor.fit(train_data, train_labels)
lr_predictions = log_regressor.predict(test_data)
accuracy = metrics.accuracy_score(test_labels, lr_predictions)
coefs = log_regressor.coef_
intercept = log_regressor.intercept_

# Create OSC sender
client = OSC.OSCClient()
client.connect( ('127.0.0.1', 9000) ) # note that the argument is a tupple and not two arguments
msg = OSC.OSCMessage() #  we reuse the same variable msg used above overwriting it
msg.setAddress("/log_reg")
msg.append(intercept)
client.send(msg) 
for c in coefs:
    msg.append(c)
    client.send(msg)

msg.setAddress("/accuracy")
msg.append(accuracy)
client.send(msg)     
client.close()

