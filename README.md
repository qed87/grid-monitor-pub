# grid-monitor
Dieser Dienst baut eine Verbindung zur Shelly Cloud auf und liest Status-Updates von ausgewählten Devices (Solaranlage sowie Energiemeter im Hausverteiler) ein, transformiert diese Updates und aktualisert daraufhin Prometheus Metriken (Instrumentalisierung). Die Zeitreihen von Prometheus werden in Grafana in einem Dashboard
aufbereitet.

## Device Übersicht
1. Solaranlage (*SHPLG-S*): Erfasst die Einspeisung der Solaranlage in den Haushalt.
2. Verbrauchszähler Verteilerkasten (*SHEM-3*): Erfasst den Haushaltsverbrauch auf allen drei Phasen. Wird Strom verbraucht, dann liegt ein Verbrauch >= 0 vor. Andernfalls liegt ein negativer vor und signalisiert eine Einspeisung von Solarstrom ins Netz.

## Anwendungsbestandteile
Diese Anwendung hostet einen Endpunkt (/metrics), der von Prometheus in regelmäßigen Zeitintervallen konsumiert wird. 

Des Weiteren startet diese Anwendung einen Hintergrunddienst, der eine Websocket-Verbindung zur Shelly-Cloud aufbaut und Statusupdates der smarten Shelly-Devices konsumiert.

## Metriken
1. **infeed_energy**: Eingespeiste Leistung in Watt.
2. **energy_used**: Kostenwirksame Leistung (Vebrauch) im Haushalt in Watt.
3. **energy_total_used**: Tatsächliche Leistung (Vebrauch) im Haushalt in Watt.
4. **solar_produced**: Tatsächliche Leistung (Erzeugung) der Solaranlage in Watt.
5. **solar_used**: Genutzte Leistung (Erzeugung) der Solaranlage in Watt.

## Tools used
- Generated classes in folder ./Data/ShellyApi/ with https://www.jetbrains.com/help/rider/Generate_classes_from_json.html 