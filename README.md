# AzureServiceBusSample

This project demonstrates how to Send to or Receive from AzureServiceBus with .Net Core. 

The solution has 3 project present Client-Sider (Publisher), Server-Side (Consumer) and Shared Library for DTOs.


# ClientApi (Publisher)

It manages to send your messages to Service Bus Queue or Service Bus Topic. You may choose to use direct Queue or you may categorize your messages by topic name and its filter on Azure Portal.
Once you've done with your configuration on Azure portal for Queue or Topics, you may use ClientApi to send the messages either to Queue or Topic.


# Server (Consumer)

Server-Side project is developed based on consumer pattern. There are two types of consumer for Azure Service Bus, as Client-Side has, Topic Consumer or Queue Consumer.
You may easily consume either queue or topic, or both at the same time.

# Shared Library

I've just keep my DTOs on this library so I can easily access from both sides.
