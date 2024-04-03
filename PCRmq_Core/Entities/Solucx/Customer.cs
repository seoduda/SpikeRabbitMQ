namespace PCRmq_Core.Entities.Solucx
{
    public class Customer
    {
        public string id { get; set; }
        public string client_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string phone2 { get; set; }
        public string cpf { get; set; }
        public object gender { get; set; }
        public bool opt_out { get; set; }
        public DateTime CreationDate { get; set; }
    }
}