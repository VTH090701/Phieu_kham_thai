namespace Phieu_khai_thai.Data
{
    public class ResponseApi<T>
    {
        public string? Code { get; set; }
        public string? Type { get; set; }
        
        public T? Value { get; set; }

        public string? Status { get; set; }
        public string? Message { get; set; }
    }

    public class ResponLogin<T>
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Work { get; set; }
        public string? Token { get; set; }
        public string? Display { get; set; }
        public string? Expired { get; set; }
        public string? User_name { get; set; }
        public bool? Is_change_now { get; set; }
        public List<T>? Functions { get; set; }
        public object? Organization { get; set; }
    }

    public class Function
    {
        public string? Code { get; set; }
        public bool? Allow { get; set; }
        public bool? Default { get; set; }
        public string? Display { get; set; }
    }

    public class DataLocation
    {
        public string? Code { get; set; }
        public string? Type { get; set; }
        public bool? Admin { get; set; }
        public bool? Allow { get; set; }
        public int? Value { get; set; }
        public bool? Default { get; set; }
        public string? Display { get; set; }
        public string? Type_Code { get; set; }
        public bool? Role_Group { get; set; }
        public string? Type_Display { get; set; }
    }

    public class Eninlocation
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Start { get; set; }
        public string? Gender { get; set; }
        public int? Subject { get; set; }
        public string? Birthdate { get; set; }
        public int? Encounter { get; set; }
        public string? Fee_Object { get; set; }
        public string? Classify_Code { get; set; }
        public string? Classify_Name { get; set; }
        public string? Processing_Status { get; set; }

    }

    public class EncounterInfo
    {
        public string? Ci { get; set; }
        public string? Job { get; set; }
        public object? Card { get; set; }
        public string? Name { get; set; }
        public DateTime? Start { get; set; }
        public string? Ethnic { get; set; }
        public string? Address { get; set; }
        public int? Subject { get; set; }
        public List<LocationEncounter>? Location { get; set; }
        public string? Date_End { get; set; }
        public string? Birthdate { get; set; }
        public int Encounter { get; set; }
        public string? Birth_year { get; set; }
        public DateTime? Date_Start { get; set; }
        public string? diagnostic { get; set; }
        public string? Fee_Object { get; set; }
        public string? Gender_Name { get; set; }
        public string? Nationality { get; set; }
        public Organization? Organization { get; set; }
    }

    public class Organization
    {
        public string? Code { get; set; }
        public int? Value { get; set; }
        public string? Display { get; set; }
    }

    public class LocationEncounter
    {
        public long  Seq { get; set; }
        public string? Code { get; set; }
        public int? Value { get; set; }
        public string? Display { get; set; }
        public string? Fee_Object { get; set; }

    }
    public class DataDoctor
    {
        public int Id { get; set; }
        public int? Org_Id { get; set; }
        public string? Display { get; set; }
        public string? Org_Display { get;set; }
    }

    public class responseSaveData
    {
        public string code { set; get; }
        public string type { set; get; }
        public string hints { set; get; }
        public string owner { set; get; }
        public string value { set; get; }
        public string status { set; get; }
        public string message { set; get; }
    }
    public class responseSaveComeBack
    {
        public string code { set; get; }
        public string type { set; get; }
        public string hints { set; get; }
        public string status { set; get; }
        public string message { set; get; }
    }



    public class responseListVisit
    {
        public string Code { set; get; }
        public string Type { set; get; }
        public string Hints { set; get; }
        public List<ListVisit> Value { set; get; }
        
        public string Status { set; get; }
        public string Message { set; get; }

    }
    public class ListVisit
    {
        public string Id { set; get; }
        public List<Visit> Value { set; get; }

        public string Visit { set; get; }

        public string Doctor { set; get; }
        public string Status { set; get; }


        public string Created { set; get; }
        
        public int Encounter { set; get; }

        public string Staservice_Requesttus { set; get; }

        
    }
    public class Visit
    {
        public string Code { set; get; }
        public List<object> Value { set; get; }

    }
    public class ComebackEdit
    {
        public string? At { set; get; }
        public string? Id { set; get; }
        public int?  Org { set; get; }
        public string? Code { set; get; }
        public int? Value { set; get; }
        public string? Doctor { set; get; }
        public string? Display { set; get; }
    
    
    }
}
