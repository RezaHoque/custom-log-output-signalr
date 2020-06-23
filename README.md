# custom-log-output-signalr
Outputting the log as soon as it happens in a page. Like a log dashboard.

This is just to demonstrate the possibilities of showing the log output in a dashboard as soon as it triggers by creating a custom log provider on the top of asp.net core default log provider.

This project is highly inspired by <a href="https://asp.net-hacker.rocks/2017/05/05/add-custom-logging-in-aspnetcore.html" target="_blank"> custom log made by Jürgen Gutsch</a>.

Live demo: https://customlog.azurewebsites.net/

Keep "/log" page open and go to "/customer" and "/" page in a different browser tab. 

Those page will generate logs and will be displayed real time "/log" page.
