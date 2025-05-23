import json

class ECGHeaderDTO:
    def __init__(self):
        self.class_code = "ECG"
        self.xsi_type = "Waveform"
        self.code = ""
        self.code_system = ""
        self.code_system_name = ""
        self.head_value = 0.0
        self.head_unit = "mV"
        self.increment_value = 1.0
        self.increment_unit = "ms"

    def to_dict(self):
        """Convert the object to a dictionary."""
        return {
            "class_code": self.class_code,
            "xsi_type": self.xsi_type,
            "code": self.code,
            "code_system": self.code_system,
            "code_system_name": self.code_system_name,
            "head_value": self.head_value,
            "head_unit": self.head_unit,
            "increment_value": self.increment_value,
            "increment_unit": self.increment_unit,
        }

#'{"ClassCode":"OBS","XsiType":"GLIST_PQ","Code":"TIME_RELATIVE",
# "CodeSystem":"2.16.840.1.113883.6.24","CodeSystemName":"MDC","HeadValue":"0","HeadUnit":"s",
# "IncrementValue":"2","IncrementUnit":"s"}'
    @classmethod
    def from_dict(cls, data):
        """Create an object from a dictionary."""
        obj = cls()
        obj.class_code = data.get("ClassCode", "ECG")
        obj.xsi_type = data.get("XsiType", "Waveform")
        obj.code = data.get("Code", "")
        obj.code_system = data.get("CodeSystem", "")
        obj.code_system_name = data.get("CodeSystemName", "")
        obj.head_value = data.get("HeadValue", 0.0)
        obj.head_unit = data.get("HeadUnit", "mV")
        obj.increment_value = data.get("IncrementValue", 1.0)
        obj.increment_unit = data.get("IncrementUnit", "ms")
        return obj

    def __str__(self):
        return (f"ECGHeaderDTO: [ClassCode: {self.class_code}, XsiType: {self.xsi_type}, "
                f"Code: {self.code}, CodeSystem: {self.code_system}, "
                f"CodeSystemName: {self.code_system_name}, HeadValue: {self.head_value} {self.head_unit}, "
                f"IncrementValue: {self.increment_value} {self.increment_unit}]")

# Serialize to JSON    
def serialize_to_json(ecg_header):
    """Serialize an ECGHeaderDTO object to a JSON string."""
    ecg_dict = ecg_header.to_dict()
    return json.dumps(ecg_dict, indent=4)


# Deserialize from JSON
def deserialize_from_json(json_str):
    """Deserialize a JSON string to an ECGHeaderDTO object."""
    data = json.loads(json_str)
    return ECGHeaderDTO.from_dict(data)