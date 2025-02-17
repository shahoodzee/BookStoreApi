namespace DU.Common.Param.Device;

public record UpdateDeviceParam(
    long uddi,    // Device Id
    string udsn,  // serial number
    string uds,   // simNumber
    string udgs,  // grabbaSerial
    string udfi,  // firstIMEI
    string udsi,  // Second IMEI
    int udds,     // Device Status Id
    int udsti,     // Device state Id
    DateTime udwe,  // Warrenty End Date
    int uddm,     // Device Model Id
    long udmui,    // Modified By user Id
    //int uppi,      // POS ID
    decimal upln,   // longitude
    decimal uplt    // latitude
);
    

