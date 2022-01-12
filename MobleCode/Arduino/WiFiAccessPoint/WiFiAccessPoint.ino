//Masoud Rajaei 
//Mr.rajjaei@gmail.com
//this code is simple just for test

#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <ESP8266WebServer.h>

#ifndef APSSID
#define APSSID "SocketTest"
#define APPSK  "123456789"
#endif

/* Set these to your desired credentials. */
const char *ssid = APSSID;
const char *password = APPSK;

ESP8266WebServer server(80);

void handleRoot() {
  server.send(200, "text/html", "<h1>You are connected</h1>");
}

void setup() {
	
  delay(10);
  
  Serial.begin(115200);
  Serial.println();
  Serial.print("Configuring access point...");
  
  
  WiFi.softAP(ssid, password);

  IPAddress myIP = WiFi.softAPIP();
  server.on("/", handleRoot);
  server.begin();

  Serial.print("AP IP address: ");
  Serial.println(myIP);
  Serial.println("HTTP server started");
}

void loop() {
  
   WiFiClient client = server.client();
   server.handleClient();

  
  if (client) {
 
    while (client.connected()) {
        if (client.available() > 0)
        {
            Serial.print("Get Count");
            Serial.println(client.available());
        }
      while (client.available()>0) {
        char c = client.read();
        Serial.write(c);
      }
      delay(10);
    }
 
    client.stop();
    Serial.println("Client disconnected");
 
  }
}
