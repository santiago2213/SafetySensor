// DHT sensor library - Version: Latest 
#include <DHT.h>
#include <DHT_U.h>

#include <Arduino_SensorKit.h>
#include <Arduino_SensorKit_BMP280.h>
#include <Arduino_SensorKit_LIS3DHTR.h>


unsigned long myTime;

void setup() {
  Serial.begin(9600);
  Pressure.begin();
}


void loop() {
  
  Serial.print("Time: ");
  myTime = millis() / 1000;

  Serial.print(myTime);// prints time since program started
  Serial.println("s");
  
  // Get and print temperatures
  Serial.print("Temp: ");
  Serial.print(Pressure.readTemperature() * 1.8 + 32);
  Serial.println("*F"); // The unit for Celsius because original Arduino don't support special symbols

  // Get and print atmospheric pressure data
  Serial.print("Pressure: ");
  Serial.print(Pressure.readPressure());
  Serial.println("Pa");
  
    Serial.println("\n");//add a line between output of different times.

  delay(1000);          // wait a second so as not to send massive amounts of data
}