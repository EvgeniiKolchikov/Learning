namespace Learning;

public class ClassLessonHomeWork
{
    public string Name { get; set; }
    public int AnimalType { get; set; }

    public int Diagnosis{ get; set;}

    public ClassLessonHomeWork(string name, AnimalTypeEnum animalType, DiagnosisEnum diagnosis = DiagnosisEnum.ItWillPass)
    {
        Name = name;
        AnimalType = (int)animalType;
        Diagnosis = (int)diagnosis;
    }

    public enum AnimalTypeEnum
    {
        Cat = 1,
        Dog = 2,
        Cavy = 3,
        Parrot = 4
    }

    public enum DiagnosisEnum
    {
        Medicate = 1,
        Surgery = 2,
        ItWillPass = 3
    }

    public void AddDiagnosis(DiagnosisEnum diagnosis)
    {
        Diagnosis = (int)diagnosis;
    }

    public void CalculateCostService()
    {
        
    }
}