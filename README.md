# StockNotifications

This app will toast a notification if the difference between the A and B stock of Handelsbanken is greater than 0.80 SEK. It remembers notifications for an hour, and won't toast another notification during that time.

However, if the less valued stock becomes higher valued than the other one, the app will toast a new notification for this new event.

Use the app to get notifications when you can buy more Handelsbanken stocks by swapping the higher valued stock for the less valued stock. Probably only applicable if you own your stocks via an ISK.

## Tech
The app uses Topshelf, together with Quartz and StructureMap, and fetches real time data from Yahoo. Nasdaq is also a usable source, but the data is 15 min delayed.

[BurntToast](https://github.com/Windos/BurntToast) is used to toast notifications.

## Contribute
Of course the app could be extended to check for any interesting stock event, such as MA50 breaking throuh MA200. Free to use in any way.

Peace out.