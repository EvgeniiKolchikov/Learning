namespace Learning;

public class ClassLessonHomeWork
{
    public string Name { get; set; }

    private int _animalType;
    public int AnimalType
    {
        set { AnimalSetCheck(value); }
        get { return _animalType; }
    }

    private int _diagnosis = 3;
    public int Diagnosis
    {
        set { DiagnosisSetCheck(value); }
        get { return _diagnosis; }
    }
    
    private int _initialInspectionCost;
    private int _totalCost;

    public ClassLessonHomeWork(string name, int animalType)
    {
        Name = name;
        AnimalSetCheck(animalType);
    }
    public ClassLessonHomeWork(string name, int animalType, int diagnosis = (int)DiagnosisEnum.NoHelp)
    {
        Name = name;
        AnimalSetCheck(animalType);
        DiagnosisSetCheck(diagnosis);
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
        NoHelp = 3
    }

    public void AddDiagnosis(DiagnosisEnum diagnosis)
    {
        Diagnosis = (int)diagnosis;
        TotalCostCalculate();
    }
    public override string ToString()
    {
        InitialCostCheck();
        TotalCostCalculate();
        return $"{Name}, {(AnimalTypeEnum)AnimalType}, {((DiagnosisEnum)Diagnosis)}, {_totalCost.ToString()}";
    }

    private void AnimalSetCheck(int value)
    {
        if (value > 0 && value <= Enum.GetNames(typeof(AnimalTypeEnum)).Length)
        {
            _animalType = value;
            return;
        }
        
        throw new ArgumentException(
            $"Введите значение в диапазоне от 1 до {Enum.GetNames(typeof(AnimalTypeEnum)).Length}");
    }
    private void DiagnosisSetCheck(int value)
    {
        if (value > 0 && value <= Enum.GetNames(typeof(DiagnosisEnum)).Length)
        {
            _diagnosis = value;
            return;
        }
        throw new ArgumentException(
            $"Введите значение в диапазоне от 1 до {Enum.GetNames(typeof(DiagnosisEnum)).Length}");
    }
    private void InitialCostCheck()
    {
        switch (AnimalType)
        {
            case (int)AnimalTypeEnum.Dog:
                _initialInspectionCost = 1000;
                break;
            case (int)AnimalTypeEnum.Cat:
                _initialInspectionCost = 800;
                break;
            case (int)AnimalTypeEnum.Cavy:
                _initialInspectionCost = 200;
                break;
            case (int)AnimalTypeEnum.Parrot:
                _initialInspectionCost = 500;
                break;
        }
    }
    private void TotalCostCalculate()
    {
        switch (Diagnosis)
        {
            case (int)DiagnosisEnum.Medicate:
                _totalCost = _initialInspectionCost * 2;
                break;
            case (int)DiagnosisEnum.Surgery:
                _totalCost = _initialInspectionCost * 5;
                break;
            case (int)DiagnosisEnum.NoHelp:
                _totalCost = _initialInspectionCost;
                break;
        }
        
    }
}