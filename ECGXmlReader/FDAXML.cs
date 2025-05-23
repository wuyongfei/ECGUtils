using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECGXmlReader;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class AnnotatedECG
{

    private AnnotatedECGID idField;

    private AnnotatedECGEffectiveTime effectiveTimeField;

    private AnnotatedECGComponentOf componentOfField;

    private AnnotatedECGComponent componentField;

    private string typeField;

    private string classCodeField;

    /// <remarks/>
    public AnnotatedECGID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGEffectiveTime effectiveTime
    {
        get
        {
            return this.effectiveTimeField;
        }
        set
        {
            this.effectiveTimeField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOf componentOf
    {
        get
        {
            return this.componentOfField;
        }
        set
        {
            this.componentOfField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponent component
    {
        get
        {
            return this.componentField;
        }
        set
        {
            this.componentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGID
{

    private string rootField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGEffectiveTime
{

    private AnnotatedECGEffectiveTimeCenter centerField;

    /// <remarks/>
    public AnnotatedECGEffectiveTimeCenter center
    {
        get
        {
            return this.centerField;
        }
        set
        {
            this.centerField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGEffectiveTimeCenter
{

    private System.DateTime valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOf
{

    private AnnotatedECGComponentOfTimepointEvent timepointEventField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEvent timepointEvent
    {
        get
        {
            return this.timepointEventField;
        }
        set
        {
            this.timepointEventField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEvent
{

    private AnnotatedECGComponentOfTimepointEventCode codeField;

    private AnnotatedECGComponentOfTimepointEventEffectiveTime effectiveTimeField;

    private AnnotatedECGComponentOfTimepointEventPerformer performerField;

    private AnnotatedECGComponentOfTimepointEventComponentOf componentOfField;

    private string classCodeField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventCode code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventEffectiveTime effectiveTime
    {
        get
        {
            return this.effectiveTimeField;
        }
        set
        {
            this.effectiveTimeField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventPerformer performer
    {
        get
        {
            return this.performerField;
        }
        set
        {
            this.performerField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOf componentOf
    {
        get
        {
            return this.componentOfField;
        }
        set
        {
            this.componentOfField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventCode
{

    private string codeField;

    private string codeSystemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystem
    {
        get
        {
            return this.codeSystemField;
        }
        set
        {
            this.codeSystemField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventEffectiveTime
{

    private AnnotatedECGComponentOfTimepointEventEffectiveTimeCenter centerField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventEffectiveTimeCenter center
    {
        get
        {
            return this.centerField;
        }
        set
        {
            this.centerField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventEffectiveTimeCenter
{

    private System.DateTime valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventPerformer
{

    private AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformer studyEventPerformerField;

    private string typeCodeField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformer studyEventPerformer
    {
        get
        {
            return this.studyEventPerformerField;
        }
        set
        {
            this.studyEventPerformerField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string typeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformer
{

    private AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformerID idField;

    private AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformerAssignedPerson assignedPersonField;

    private string classCodeField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformerID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformerAssignedPerson assignedPerson
    {
        get
        {
            return this.assignedPersonField;
        }
        set
        {
            this.assignedPersonField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformerID
{

    private string rootField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventPerformerStudyEventPerformerAssignedPerson
{

    private object nameField;

    private string classCodeField;

    /// <remarks/>
    public object name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOf
{

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignment subjectAssignmentField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignment subjectAssignment
    {
        get
        {
            return this.subjectAssignmentField;
        }
        set
        {
            this.subjectAssignmentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignment
{

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubject subjectField;

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinition definitionField;

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOf componentOfField;

    private string classCodeField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubject subject
    {
        get
        {
            return this.subjectField;
        }
        set
        {
            this.subjectField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinition definition
    {
        get
        {
            return this.definitionField;
        }
        set
        {
            this.definitionField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOf componentOf
    {
        get
        {
            return this.componentOfField;
        }
        set
        {
            this.componentOfField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubject
{

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubject trialSubjectField;

    private string typeCodeField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubject trialSubject
    {
        get
        {
            return this.trialSubjectField;
        }
        set
        {
            this.trialSubjectField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string typeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubject
{

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectID idField;

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPerson subjectDemographicPersonField;

    private string classCodeField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPerson subjectDemographicPerson
    {
        get
        {
            return this.subjectDemographicPersonField;
        }
        set
        {
            this.subjectDemographicPersonField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectID
{

    private string rootField;

    private string extensionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string extension
    {
        get
        {
            return this.extensionField;
        }
        set
        {
            this.extensionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPerson
{

    private string nameField;

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPersonAdministrativeGenderCode administrativeGenderCodeField;

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPersonBirthTime birthTimeField;

    private string classCodeField;

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPersonAdministrativeGenderCode administrativeGenderCode
    {
        get
        {
            return this.administrativeGenderCodeField;
        }
        set
        {
            this.administrativeGenderCodeField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPersonBirthTime birthTime
    {
        get
        {
            return this.birthTimeField;
        }
        set
        {
            this.birthTimeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPersonAdministrativeGenderCode
{

    private string codeField;

    private string codeSystemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystem
    {
        get
        {
            return this.codeSystemField;
        }
        set
        {
            this.codeSystemField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentSubjectTrialSubjectSubjectDemographicPersonBirthTime
{

    private System.DateTime valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinition
{

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinitionTreatmentGroupAssignment treatmentGroupAssignmentField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinitionTreatmentGroupAssignment treatmentGroupAssignment
    {
        get
        {
            return this.treatmentGroupAssignmentField;
        }
        set
        {
            this.treatmentGroupAssignmentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinitionTreatmentGroupAssignment
{

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinitionTreatmentGroupAssignmentCode codeField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinitionTreatmentGroupAssignmentCode code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentDefinitionTreatmentGroupAssignmentCode
{

    private string codeField;

    private string codeSystemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystem
    {
        get
        {
            return this.codeSystemField;
        }
        set
        {
            this.codeSystemField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOf
{

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOfClinicalTrial clinicalTrialField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOfClinicalTrial clinicalTrial
    {
        get
        {
            return this.clinicalTrialField;
        }
        set
        {
            this.clinicalTrialField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOfClinicalTrial
{

    private AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOfClinicalTrialID idField;

    /// <remarks/>
    public AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOfClinicalTrialID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentOfTimepointEventComponentOfSubjectAssignmentComponentOfClinicalTrialID
{

    private string rootField;

    private string extensionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string extension
    {
        get
        {
            return this.extensionField;
        }
        set
        {
            this.extensionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponent
{

    private AnnotatedECGComponentSeries seriesField;

    /// <remarks/>
    public AnnotatedECGComponentSeries series
    {
        get
        {
            return this.seriesField;
        }
        set
        {
            this.seriesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeries
{

    private AnnotatedECGComponentSeriesID idField;

    private AnnotatedECGComponentSeriesCode codeField;

    private AnnotatedECGComponentSeriesEffectiveTime effectiveTimeField;

    private AnnotatedECGComponentSeriesAuthor authorField;

    private AnnotatedECGComponentSeriesComponent componentField;

    private AnnotatedECGComponentSeriesSubjectOf subjectOfField;

    private AnnotatedECGComponentSeriesAnalysis analysisField;

    private string classCodeField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesID id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesCode code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesEffectiveTime effectiveTime
    {
        get
        {
            return this.effectiveTimeField;
        }
        set
        {
            this.effectiveTimeField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesAuthor author
    {
        get
        {
            return this.authorField;
        }
        set
        {
            this.authorField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponent component
    {
        get
        {
            return this.componentField;
        }
        set
        {
            this.componentField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesSubjectOf subjectOf
    {
        get
        {
            return this.subjectOfField;
        }
        set
        {
            this.subjectOfField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesAnalysis analysis
    {
        get
        {
            return this.analysisField;
        }
        set
        {
            this.analysisField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesID
{

    private string rootField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string root
    {
        get
        {
            return this.rootField;
        }
        set
        {
            this.rootField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesCode
{

    private string codeField;

    private string codeSystemField;

    private string codeSystemNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystem
    {
        get
        {
            return this.codeSystemField;
        }
        set
        {
            this.codeSystemField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystemName
    {
        get
        {
            return this.codeSystemNameField;
        }
        set
        {
            this.codeSystemNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesEffectiveTime
{

    private AnnotatedECGComponentSeriesEffectiveTimeLow lowField;

    private AnnotatedECGComponentSeriesEffectiveTimeHigh highField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesEffectiveTimeLow low
    {
        get
        {
            return this.lowField;
        }
        set
        {
            this.lowField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesEffectiveTimeHigh high
    {
        get
        {
            return this.highField;
        }
        set
        {
            this.highField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesEffectiveTimeLow
{

    private ulong valueField;

    private bool inclusiveField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ulong value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool inclusive
    {
        get
        {
            return this.inclusiveField;
        }
        set
        {
            this.inclusiveField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesEffectiveTimeHigh
{

    private ulong valueField;

    private bool inclusiveField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ulong value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool inclusive
    {
        get
        {
            return this.inclusiveField;
        }
        set
        {
            this.inclusiveField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesAuthor
{

    private AnnotatedECGComponentSeriesAuthorManufacturedProduct manufacturedProductField;

    private string typeCodeField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesAuthorManufacturedProduct manufacturedProduct
    {
        get
        {
            return this.manufacturedProductField;
        }
        set
        {
            this.manufacturedProductField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string typeCode
    {
        get
        {
            return this.typeCodeField;
        }
        set
        {
            this.typeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesAuthorManufacturedProduct
{

    private AnnotatedECGComponentSeriesAuthorManufacturedProductManufacturedDevice manufacturedDeviceField;

    private AnnotatedECGComponentSeriesAuthorManufacturedProductManufacturerOrganization manufacturerOrganizationField;

    private string classCodeField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesAuthorManufacturedProductManufacturedDevice manufacturedDevice
    {
        get
        {
            return this.manufacturedDeviceField;
        }
        set
        {
            this.manufacturedDeviceField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesAuthorManufacturedProductManufacturerOrganization manufacturerOrganization
    {
        get
        {
            return this.manufacturerOrganizationField;
        }
        set
        {
            this.manufacturerOrganizationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesAuthorManufacturedProductManufacturedDevice
{

    private byte manufacturerModelNameField;

    private object softwareNameField;

    private string classCodeField;

    /// <remarks/>
    public byte manufacturerModelName
    {
        get
        {
            return this.manufacturerModelNameField;
        }
        set
        {
            this.manufacturerModelNameField = value;
        }
    }

    /// <remarks/>
    public object softwareName
    {
        get
        {
            return this.softwareNameField;
        }
        set
        {
            this.softwareNameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesAuthorManufacturedProductManufacturerOrganization
{

    private ushort nameField;

    private string classCodeField;

    /// <remarks/>
    public ushort name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponent
{

    private AnnotatedECGComponentSeriesComponentSequenceSet sequenceSetField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponentSequenceSet sequenceSet
    {
        get
        {
            return this.sequenceSetField;
        }
        set
        {
            this.sequenceSetField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSet
{

    private AnnotatedECGComponentSeriesComponentSequenceSetComponent[] componentField;

    private string classCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("component")]
    public AnnotatedECGComponentSeriesComponentSequenceSetComponent[] component
    {
        get
        {
            return this.componentField;
        }
        set
        {
            this.componentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSetComponent
{

    private AnnotatedECGComponentSeriesComponentSequenceSetComponentSequence sequenceField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponentSequenceSetComponentSequence sequence
    {
        get
        {
            return this.sequenceField;
        }
        set
        {
            this.sequenceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSetComponentSequence
{

    private AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceCode codeField;

    private AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValue valueField;

    private string classCodeField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceCode code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValue value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string classCode
    {
        get
        {
            return this.classCodeField;
        }
        set
        {
            this.classCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceCode
{

    private string codeField;

    private string codeSystemField;

    private string codeSystemNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystem
    {
        get
        {
            return this.codeSystemField;
        }
        set
        {
            this.codeSystemField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystemName
    {
        get
        {
            return this.codeSystemNameField;
        }
        set
        {
            this.codeSystemNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValue
{

    private AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueOrigin originField;

    private AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueScale scaleField;

    private string digitsField;

    private AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueHead headField;

    private AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueIncrement incrementField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueOrigin origin
    {
        get
        {
            return this.originField;
        }
        set
        {
            this.originField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueScale scale
    {
        get
        {
            return this.scaleField;
        }
        set
        {
            this.scaleField = value;
        }
    }

    /// <remarks/>
    public string digits
    {
        get
        {
            return this.digitsField;
        }
        set
        {
            this.digitsField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueHead head
    {
        get
        {
            return this.headField;
        }
        set
        {
            this.headField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueIncrement increment
    {
        get
        {
            return this.incrementField;
        }
        set
        {
            this.incrementField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueOrigin
{

    private byte valueField;

    private string unitField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unit
    {
        get
        {
            return this.unitField;
        }
        set
        {
            this.unitField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueScale
{

    private decimal valueField;

    private string unitField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unit
    {
        get
        {
            return this.unitField;
        }
        set
        {
            this.unitField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueHead
{

    private byte valueField;

    private string unitField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unit
    {
        get
        {
            return this.unitField;
        }
        set
        {
            this.unitField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesComponentSequenceSetComponentSequenceValueIncrement
{

    private byte valueField;

    private string unitField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unit
    {
        get
        {
            return this.unitField;
        }
        set
        {
            this.unitField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesSubjectOf
{

    private AnnotatedECGComponentSeriesSubjectOfComponent[] annotationSetField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("component", IsNullable = false)]
    public AnnotatedECGComponentSeriesSubjectOfComponent[] annotationSet
    {
        get
        {
            return this.annotationSetField;
        }
        set
        {
            this.annotationSetField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesSubjectOfComponent
{

    private AnnotatedECGComponentSeriesSubjectOfComponentAnnotation annotationField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesSubjectOfComponentAnnotation annotation
    {
        get
        {
            return this.annotationField;
        }
        set
        {
            this.annotationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesSubjectOfComponentAnnotation
{

    private AnnotatedECGComponentSeriesSubjectOfComponentAnnotationCode codeField;

    private AnnotatedECGComponentSeriesSubjectOfComponentAnnotationValue valueField;

    /// <remarks/>
    public AnnotatedECGComponentSeriesSubjectOfComponentAnnotationCode code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    public AnnotatedECGComponentSeriesSubjectOfComponentAnnotationValue value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesSubjectOfComponentAnnotationCode
{

    private string codeField;

    private string codeSystemField;

    private string codeSystemNameField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string code
    {
        get
        {
            return this.codeField;
        }
        set
        {
            this.codeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystem
    {
        get
        {
            return this.codeSystemField;
        }
        set
        {
            this.codeSystemField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string codeSystemName
    {
        get
        {
            return this.codeSystemNameField;
        }
        set
        {
            this.codeSystemNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesSubjectOfComponentAnnotationValue
{

    private decimal valueField;

    private string unitField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unit
    {
        get
        {
            return this.unitField;
        }
        set
        {
            this.unitField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class AnnotatedECGComponentSeriesAnalysis
{

    private string greadField;

    private object digcodeField;

    private object miscodeField;

    /// <remarks/>
    public string gread
    {
        get
        {
            return this.greadField;
        }
        set
        {
            this.greadField = value;
        }
    }

    /// <remarks/>
    public object digcode
    {
        get
        {
            return this.digcodeField;
        }
        set
        {
            this.digcodeField = value;
        }
    }

    /// <remarks/>
    public object miscode
    {
        get
        {
            return this.miscodeField;
        }
        set
        {
            this.miscodeField = value;
        }
    }
}



internal class FDAXML
{
}

