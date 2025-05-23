import json
from datetime import datetime
from typing import List

class LabelInfo:
    def __init__(self):
        self.label_type = ""
        self.lead = ""
        self.start_x = 0
        self.start_y = 0
        self.end_x = 0
        self.end_y = 0
        self.author = ""
        self.create_date = datetime.now()

    def to_dict(self):
        """Convert the object to a dictionary."""
        return {
            "label_type": self.label_type,
            "lead": self.lead,
            "start_x": self.start_x,
            "start_y": self.start_y,
            "end_x": self.end_x,
            "end_y": self.end_y,
            "author": self.author,
            "create_date": self.create_date.isoformat(),  # Convert datetime to string
        }

# {"LabelType":"P0","Lead":"II","StartX":2281,"StartY":-5,"EndX":2552,"EndY":-9,"Author":"1001","CreateDate":"2025-02-25T11:55:52.5738893-05:00"}
    @classmethod
    def from_dict(cls, data):
        """Create an object from a dictionary."""
        obj = cls()
        obj.label_type = data.get("LabelType", "")
        obj.lead = data.get("Lead", "")
        obj.start_x = data.get("StartX", 0)
        obj.start_y = data.get("StartY", 0)
        obj.end_x = data.get("EndX", 0)
        obj.end_y = data.get("EndY", 0)
        obj.author = data.get("Author", "")
        create_date_str = data.get("CreateDate", "")
        obj.create_date = datetime.fromisoformat(create_date_str) if create_date_str else datetime.now()
        return obj

    def __str__(self):
        return (f"LabelInfo: [LabelType: {self.label_type}, Lead: {self.lead}, "
                f"StartX: {self.start_x}, StartY: {self.start_y}, "
                f"EndX: {self.end_x}, EndY: {self.end_y}, "
                f"Author: {self.author}, CreateDate: {self.create_date}]")


# Serialize a list of LabelInfo objects to JSON
def serialize_to_json(labels: List[LabelInfo]):
    """Serialize a list of LabelInfo objects to a JSON string."""
    labels_dict = [label.to_dict() for label in labels]
    return json.dumps(labels_dict, indent=4)


# Deserialize a JSON string to a list of LabelInfo objects
def deserialize_from_json(json_str: str) -> List[LabelInfo]:
    """Deserialize a JSON string to a list of LabelInfo objects."""
    data = json.loads(json_str)
    return [LabelInfo.from_dict(label_data) for label_data in data]