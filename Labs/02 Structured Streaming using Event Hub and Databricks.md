### Simple simplified use case of an IBOR solution
The scenario is as below:
* Each time an event (transaction) is received both cash and asset positions will be impacted
* Value will be added/subtracted to/from the cash position for each event
* Value will be added/subtracted to/from asset position for each event
* Portfolio will be evaluated for each event
<br> **Structured Streaming using Event Hub with Databricks** notebook contains the code to connect to the Azure Event Hub and consume the events
<br> Program.cs is a simple code to send messages to the Azure Event Hub created
<br> Ibor-transactions.json is a fine example sent to the Azure Event Hub

<br>Here are the steps to follow:
* Setup Azure event hubs and Azure Databricks with this article [Azure Event Hub Azure Databrick](https://learn.microsoft.com/en-us/azure/event-hubs/event-hubs-create)
* Run StreamData solution which is under **Event Hub Streaming App** folder to send event(s) to EventHub (make sure to update the file with the file path used to send an event and also the connection string key of your Azure Event Hub). You can clone the following repo to get access to the Solution file.
```
https://github.com/krish1711/DataBricks.git
```
* Install the following SDK in the Spakr cluster under Maven menu.
```
com.microsoft.azure:azure-eventhubs-spark_2.11:2.3.17
```
* Import the notebook into your Databricks from the below-given link and run it to create the stream.
 ```
https://raw.githubusercontent.com/krish1711/DataBricks/main/Notebooks/Structured%20Streaming%20using%20Event%20Hub%20with%20Databricks.ipynb
 ```
* Run the cell (the one before stopping the stream) to visualize how the portfolio valuation is updated

* Follow the rest of the instructions in the Notebook.
