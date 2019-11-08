# NotifyIPAddr
공인아이피를 Slack Webhook App을 통해 알려주는 윈도우 서비스 프로그램

# 설치방법
```
> git clone https://github.com/human109/NotifyIPAddr.git NotifyIPAddr

> cd NotifyIPAddr

NotifyIPAddr> dotnet build -c Release

NotifyIPAddr> cd notifyIpaddr\bin\Release\netcoreapp3.0

NotifyIPAddr\notifyIpaddr\bin\Release\netcoreapp3.0> notifyIpaddr.exe install
```


# 설정파일
```json
# RUNTIME_DIRECTORY\appsettings.json
{
    "slack": {
        "Url": "YOUR_WEBHOOK_URL",
        "Channel": "YOUR_CHANNEL"
    }
}
```
