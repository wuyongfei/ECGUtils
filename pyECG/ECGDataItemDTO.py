import json

class ECGDataItemDTO:
    def __init__(self):
        self.class_code = "ECG"
        self.xsi_type = "Waveform"
        self.code = ""
        self.code_system = ""
        self.code_system_name = ""
        self.origin_value = ""
        self.origin_unit = ""
        self.scale_value = ""
        self.scale_unit = ""

    def to_dict(self):
        """Convert the object to a dictionary."""
        return {
            "class_code": self.class_code,
            "xsi_type": self.xsi_type,
            "code": self.code,
            "code_system": self.code_system,
            "code_system_name": self.code_system_name,
            "origin_value": self.origin_value,
            "origin_unit": self.origin_unit,
            "scale_value": self.scale_value,
            "scale_unit": self.scale_unit,
        }

#'{"ClassCode":"OBS","XsiType":"SLIST_PQ","Code":"MDC_ECG_LEAD_II",
# "CodeSystem":"2.16.840.1.113883.6.24","CodeSystemName":"MDC",
# "OriginValue":"0","OriginUnit":"uV","ScaleValue":"4.88","ScaleUnit":"uV"}'
    @classmethod
    def from_dict(cls, data):
        """Create an object from a dictionary."""
        obj = cls()
        obj.class_code = data.get("ClassCode", "ECG")
        obj.xsi_type = data.get("XsiType", "Waveform")
        obj.code = data.get("Code", "")
        obj.code_system = data.get("CodeSystem", "")
        obj.code_system_name = data.get("CodeSystemName", "")
        obj.origin_value = data.get("OriginValue", "")
        obj.origin_unit = data.get("OriginUnit", "")
        obj.scale_value = data.get("ScaleValue", "")
        obj.scale_unit = data.get("ScaleUnit", "")
        return obj

    def __str__(self):
        return (f"ECGDataItemDTO: [ClassCode: {self.class_code}, XsiType: {self.xsi_type}, "
                f"Code: {self.code}, CodeSystem: {self.code_system}, "
                f"CodeSystemName: {self.code_system_name}, OriginValue: {self.origin_value} {self.origin_unit}, "
                f"ScaleValue: {self.scale_value} {self.scale_unit}]")


# Serialize to JSON
def serialize_to_json(ecg_data_item):
    """Serialize an ECGDataItemDTO object to a JSON string."""
    ecg_dict = ecg_data_item.to_dict()
    return json.dumps(ecg_dict, indent=4)


# Deserialize from JSON
def deserialize_from_json(json_str):
    """Deserialize a JSON string to an ECGDataItemDTO object."""
    data = json.loads(json_str)
    return ECGDataItemDTO.from_dict(data)