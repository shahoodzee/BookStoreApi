namespace DU.Common.Param.Device;

public record CreateDeviceParam(
   string ctser, // Serial 
   string ctsn, // Sim Number
   string ctgs, // Grabba Serial
   string ctfi, // First IMEI 
   string ctsi, // Second IMEI
   DateTime ctwe, // Warrenty End Date
   int ctdm, // Device Model
   int ctds, // Device Status
   int ctdsl ,  // Device State
   long ctcb, // Createdby
   decimal ctsln, // longitude
   decimal ctslt // latitude
);