import json

class LabelList:
    def __init__(self):
        self.labels = []

    def to_dict(self):
        """Convert the object to a dictionary."""
        return {
            "labels": [label.to_dict() for label in self.labels]
        }

    @classmethod
    def from_dict(cls, data):
        """Create an object from a dictionary."""
        obj = cls()
        obj.labels = [LabelInfo.from_dict(label_data) for label_data in data.get("labels", [])]
        return obj

    def __str__(self):
        return "\n".join(str(label) for label in self.labels)


# Serialize to JSON
def serialize_to_json(label_list):
    """Serialize a LabelList object to a JSON string."""
    label_dict = label_list.to_dict()
    return json.dumps(label_dict, indent=4)


# Deserialize from JSON
def deserialize_from_json(json_str):
    """Deserialize a JSON string to a LabelList object."""
    data = json.loads(json_str)
    return LabelList.from_dict(data)