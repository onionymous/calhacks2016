import requests
import datetime
#from lxml import etree
import xml.etree.ElementTree as ET

# See additional endpoints and parameters at: https://www.nasdaqdod.com/ 
url = 'http://ws.nasdaqdod.com/v1/NASDAQAnalytics.asmx/GetSummarizedTrades'

start_date = datetime.datetime.now().replace(day=1)

end_date = datetime.datetime.now()

# Change symbols and date range as needed (not more that 30 days at a time)
values = {'_Token' : 'BC2B181CF93B441D8C6342120EB0C971',
          'Symbols' : 'GOOG',
          'StartDateTime' : str(start_date).replace('-', '/'),
          'EndDateTime' : str(end_date).replace('-', '/'),
          'MarketCenters' : '' ,
          'TradePrecision': 'Hour',
          'TradePeriod':'1'}

# Submit request
response = requests.get(url, params=values)
print(response.url)

# Write to xml file
print("Writing to file...")
with open("output.xml", "w") as fout:
    fout.write(response.text)
print("Done!")

# Parse xml
# doc = etree.parse('output.xml')
# times = doc.xpath('/ArrayOfSummarizedTradeCollection[@xmlns:xsd="http://www.w3.org/2001/XMLSchema"]/SummarizedTradeCollection/SummarizedTrades/SummarizedTrade/Time')
# print(times)

tree = ET.parse('output.xml')
root = tree.getroot()

times = []
first = []
last = []
high = []
low = []
volumes = []
vwap = []
twap = []
trades = []

for child in root[0][4]:
    times.append(child[0].text)
    first.append(float(child[1].text))
    last.append(float(child[2].text))
    high.append(float(child[3].text))
    low.append(float(child[4].text))
    volumes.append(int(child[5].text))
    vwap.append(float(child[6].text))
    twap.append(float(child[7].text))
    trades.append(int(child[8].text))

fout = open("data.csv", "w")
fout.write('datetime,vwap\n')
for i in range(len(times)):
    fout.write(times[i] + ',' + str(vwap[i]) + '\n')
fout.close()