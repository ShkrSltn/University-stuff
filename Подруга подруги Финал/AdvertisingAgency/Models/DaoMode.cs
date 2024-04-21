using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using AdvertisingAgency.Models.CompositeModel;

namespace AdvertisingAgency.Models
{
    public static class DaoMode
    {
        public static void UpdateWorking(CreativeWorkModel creative, string postgreas)
        {
            Request($"Update Creative_work Set description = '{creative.description}' where id = '{creative.id}';", postgreas);
        }

        public static void FinishWorking(CreativeWorkModel creative, string postgreas)
        {
            Request($"Update Creative_work Set work_status = 'true' where id = '{creative.id}'", postgreas);
        }

        public static bool GetMediaPlanById(MediaPlanModel media, string postgreas)
        {
            foreach(string[] reader in Request($"Select * From Media_plan where id = '{media.id}'", postgreas))
            {
                media.preferences_list_id = int.Parse(reader[1]);
                media.type_of_service_id = int.Parse(reader[2]);
                media.staff_id = int.Parse(reader[3]);
                media.broadcast_time = int.Parse(reader[4]);
                media.price = float.Parse(reader[5]);
                media.status = bool.Parse(reader[6]);

                return true;
            }

            return false;
        }

        public static bool StaffLogin(StaffModel staff, string postgres)
        {
            string request = $"Select Stafflogin('{staff.tel}', '{staff.password}');";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                staff.id = int.Parse(reader[0]);
                return true;
            }
            
            return false;
        }

        public static bool GetStaffById(StaffModel staff, string postgres)
        {
            string request = $"Select * From Staff where id = '{staff.id}'";
            List<string[]> info = Request(request, postgres);

            foreach (string[] render in info)
            {
                staff.id = int.Parse(render[0]);
                staff.first_name = render[1];
                staff.last_name = render[2];
                staff.date_of_birthday = DateTime.Parse(render[3]);
                staff.sex = render[4];
                staff.tel = render[5];
                staff.password = render[6];
                return true;
            }

            return false;
        }

        public static bool GetStaffByTel(StaffModel staff, string postgres)
        {
            string request = $"Select * From Staff where tel = '{staff.tel}'";
            List<string[]> info = Request(request, postgres);

            foreach (string[] render in info)
            {
                staff.id = int.Parse(render[0]);
                staff.first_name = render[1];
                staff.last_name = render[2];
                staff.date_of_birthday = DateTime.Parse(render[3]);
                staff.sex = render[4];
                staff.tel = render[5];
                staff.password = render[6];
                return true;
            }

            return false;
        }

        public static bool AddStaff(Staff_StaffPosition_Position staff, string postgres)
        {
            if(staff.staff.first_name == "" || staff.staff.last_name == "" || staff.staff.sex == "" || staff.position.id <= 0 || staff.staff.tel == "" || staff.staff.tel.Length > 13 || staff.staff.tel.Length < 12 || staff.staff.date_of_birthday == new DateTime())
            {
                return false;
            }

            if(GetStaffByTel(staff.staff, postgres))
            {
                return false;
            }

            string request = $"Insert Into Staff(first_name,last_name,date_of_birthday,sex,tel,password) Values('{staff.staff.first_name}','{staff.staff.last_name}','{staff.staff.date_of_birthday.ToString("dd-MM-yyyy")}','{staff.staff.sex}','{staff.staff.tel}','{staff.staff.password}') Returning id";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                staff.staff.id = int.Parse(reader[0]);
            }

            staff.staffPosition = new StaffPositionModel();
            staff.staffPosition.staff_id = staff.staff.id;
            staff.staffPosition.position_id = staff.position.id;
            staff.staffPosition.start_work = DateTime.Now;

            if (AddStaffPosition(staff.staffPosition, postgres))
            {
                return false;
            }

            return true;
        }

        public static void FireStaff(StaffPositionModel staff, string postgres)
        {
            string request = $"Update Staff_Position set end_work = '{DateTime.Now.ToString("dd-MM-yyyy")}' where id = '{staff.id}';";
            Request(request, postgres);
        }

        public static bool ClientLogin(ClientCompanyModel client, string postgres)
        {
            string request = $"Select ClientLogin_tel('{client.tel}', '{client.password}');";
            List<string[]> info = Request(request, postgres);

            foreach (string[] render in info)
            {
                client.id = int.Parse(render[0]);
                return true;
            }

            request = $"Select ClientLogin_email('{client.tel}', '{client.password}');";
            info = Request(request, postgres);

            foreach (string[] render in info)
            {
                client.id = int.Parse(render[0]);
                return true;
            }

            return false;
        }

        public static bool CheckClientByCompanyName(ClientCompanyModel client, string postgres)
        {
            string request = $"Select * From Client_Company where company_name = '{client.company_name}'";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                client.id = int.Parse(reader[0]);
                client.company_name = reader[1];
                client.director = reader[2];
                client.city = reader[3];
                client.street = reader[4];
                client.first_name = reader[5];
                client.last_name = reader[6];
                client.tel = reader[7];
                client.email = reader[8];
                client.password = reader[9];
                return true;
            }

            return false;
        }

        public static bool CheckClientByTel(ClientCompanyModel client, string postgres)
        {
            string request = $"Select * From Client_Company where tel = '{client.tel}'";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                client.id = int.Parse(reader[0]);
                client.company_name = reader[1];
                client.director = reader[2];
                client.city = reader[3];
                client.street = reader[4];
                client.first_name = reader[5];
                client.last_name = reader[6];
                client.tel = reader[7];
                client.email = reader[8];
                client.password = reader[9];
                return true;
            }

            return false;
        }

        public static bool CheckClientByEmail(ClientCompanyModel client, string postgres)
        {
            string request = $"Select * From Client_Company where email = '{client.email}'";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                client.id = int.Parse(reader[0]);
                client.company_name = reader[1];
                client.director = reader[2];
                client.city = reader[3];
                client.street = reader[4];
                client.first_name = reader[5];
                client.last_name = reader[6];
                client.tel = reader[7];
                client.email = reader[8];
                client.password = reader[9];
                return true;
            }

            return false;
        }

        public static bool GetClientById(ClientCompanyModel client, string postgres)
        {
            string request = $"Select * From Client_Company Where id = '{client.id}'";

            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                client.id = int.Parse(reader[0]);
                client.company_name = reader[1];
                client.director = reader[2];
                client.city = reader[3];
                client.street = reader[4];
                client.first_name = reader[5];
                client.last_name = reader[6];
                client.tel = reader[7];
                client.email = reader[8];
                client.password = reader[9];
                return true;
            }

            return false;
        }

        public static bool AddClient(ClientCompanyModel client, string postgres)
        {
            if (client.company_name == "" || client.first_name == "" || client.last_name == "" || client.city == "" || client.street == "" || client.tel == "" || client.tel.Length > 13 || client.email == "" || client.password == "")
                return false;

            string request = $"Insert Into Client_Company (company_name, director, city, street, first_name, last_name, tel, email, password) Values('{client.company_name}','{client.director}','{client.city}','{client.street}','{client.first_name}','{client.last_name}','{client.tel}','{client.email}','{client.password}') Returning id;";
            List<string[]> info = Request(request, postgres);
            foreach(string[] reader in info)
            {
                client.id = int.Parse(reader[0]);
            }

            return true;
        }

        public static bool GetStaffPositionByStaffId(StaffPositionModel staffPosition, string postgres)
        {
            string request = $"Select * From Staff_Position where staff_id = '{staffPosition.staff_id}';";
            List<string[]> info = Request(request, postgres);

            foreach (string[] render in info)
            {
                staffPosition.id = int.Parse(render[0]);
                staffPosition.position_id = int.Parse(render[2]);
                staffPosition.start_work = DateTime.Parse(render[3]);
                if(render[4] != "")
                    staffPosition.end_work = DateTime.Parse(render[4]);
                return true;
            }

            return false;
        }

        public static bool AddStaffPosition(StaffPositionModel staffPosition, string postgres)
        {
            string request = $"Insert Into Staff_position(staff_id,position_id,start_work) Values('{staffPosition.staff_id}','{staffPosition.position_id}','{staffPosition.start_work}') Returning id;";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                staffPosition.id = int.Parse(reader[0]);
            }

            return true;
        }

        public static bool GetPreferencesListById(PreferenseListModel preference, string postgres)
        {
            string request = $"Select * From Preference_List Where id = '{preference.id}'";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                preference.client_id = int.Parse(reader[1]);
                preference.audience = reader[2];
                preference.preculiarities = reader[3];
                preference.period = int.Parse(reader[4]);
                preference.max_sum = float.Parse(reader[5]);

                return true;
            }

            return false;
        }

        public static bool AddPreferenceList(PreferenseListModel preference, string postgres)
        {
            if(preference.preculiarities.Length > 300 || preference.preculiarities == "" || preference.period <= 0 || preference.audience == "" || preference.max_sum <= 0)
            {
                return false;
            }

            string request = $"Insert Into Preference_List(client_id,audience, preculiarities,period,max_sum) Values('{preference.client_id}', '{preference.audience}', '{preference.preculiarities}', '{preference.period}', '{preference.max_sum}') Returning id";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                preference.id = int.Parse(reader[0]);
            }

            return true;
        }

        public static Client_Preferense GetNotAcceptedPreferenceListById(PreferenseListModel preferense,string postgres)
        {
            Client_Preferense preferenseLists = new Client_Preferense();

            string request = $"Select * From GetPreferenceList() where id = '{preferense.id}';";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                Client_Preferense c_p = new Client_Preferense();
                c_p.preference = new PreferenseListModel();

                c_p.preference.id = int.Parse(reader[0]);
                c_p.preference.client_id = int.Parse(reader[1]);
                c_p.preference.audience = reader[2];
                c_p.preference.preculiarities = reader[3];
                c_p.preference.period = int.Parse(reader[4]);
                c_p.preference.max_sum = float.Parse(reader[5]);

                c_p.client = new ClientCompanyModel();

                c_p.client.id = int.Parse(reader[6]);
                c_p.client.company_name = reader[7];
                c_p.client.director = reader[8];
                c_p.client.city = reader[9];
                c_p.client.street = reader[10];
                c_p.client.first_name = reader[11];
                c_p.client.last_name = reader[12];
                c_p.client.tel = reader[13];
                c_p.client.email = reader[14];

                preferenseLists = c_p;
            }

            return preferenseLists;
        }

        public static bool CheckMediaPlanByPreference(MediaPlanModel mediaPlan, string postgres)
        {
            string request = $"Select * From Media_Plan where preference_list_id = '{mediaPlan.preferences_list_id}'";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reade in info)
            {
                mediaPlan.id = int.Parse(reade[0]);
                mediaPlan.type_of_service_id = int.Parse(reade[2]);
                mediaPlan.staff_id = int.Parse(reade[3]);
                mediaPlan.broadcast_time = int.Parse(reade[4]);
                mediaPlan.price = float.Parse(reade[5]);
                mediaPlan.status = bool.Parse(reade[6]);
                return true;
            }

            return false;
        }

        public static bool AddMediaPlan(MediaPlanModel mediaPlan, string postgreas)
        {
            string request = $"Insert Into Media_Plan(preference_list_id,type_of_service_id,staff_id,broadcast_time,price,status) Values('{mediaPlan.preferences_list_id}','{mediaPlan.type_of_service_id}','{mediaPlan.staff_id}','{mediaPlan.broadcast_time}','{mediaPlan.price}','false') Returning id;";
            List<string[]> info = Request(request, postgreas);

            foreach(string[] reader in info)
            {
                mediaPlan.id = int.Parse(reader[0]);
            }

            return true;
        }

        public static bool CheckBeforeTheContractByMediaPlan(BeforeTheContractModel before, string postgres)
        {
            string request = $"Select * From Before_the_contract Where media_plan_id = '{before.media_plan_id}'";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                before.id = int.Parse(reader[0]);
                before.contract_id = int.Parse(reader[2]);
                before.start_date = DateTime.Parse(reader[3]);
                before.end_date = DateTime.Parse(reader[4]);
                return true;
            }

            return false;
        }

        public static void CloseBefore(BeforeTheContractModel before, string postgres)
        {
            string request = $"Update Before_the_contract set end_date = '{DateTime.Now.ToString("dd-MM-yyyy")}' where id = '{before.id}'";
            Request(request, postgres);
        }

        public static bool AddBefore(BeforeTheContractModel before, string postgres)
        {
            string request = $"Insert Into Before_the_contract(media_plan_id,contract_id,start_date,end_date) Values('{before.media_plan_id}','{before.contract_id}','{before.start_date.ToString("dd-MM-yyyy")}','{before.end_date.ToString("dd-MM-yyyy")}') Returning id";
            List<string[]> info = Request(request, postgres);
            foreach (string[] reader in info)
            {
                before.id = int.Parse(reader[0]);
                return true;
            }

            return false;
        }

        public static bool CheckControactByBefore(BeforeTheContractModel before, ContractModel contract, string postgres)
        {
            string request = $"Select Contract.id, company_name, first_name, last_name, total_sum, post_code, inn, payment_method, status From Contract" +
                $" Join Before_the_contract on Before_the_contract.contract_id = Contract.id and Before_the_Contract.id = '{before.id}';";
            
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                contract.id = int.Parse(reader[0]);
                contract.company_name = reader[1];
                contract.first_name = reader[2];
                contract.last_name = reader[3];
                contract.total_sum = float.Parse(reader[4]);
                contract.post_code = reader[5];
                contract.inn = int.Parse(reader[6]);
                contract.payment_method = reader[7];
                contract.status = reader[8];
                return true;
            }

            return false;
        }

        public static bool AddContract(ContractModel contract, string postgres)
        {
            if(contract.inn <= 0 || contract.post_code == "" || contract.payment_method == "")
            {
                return false;
            }

            string request = $"Insert Into Contract(company_name,first_name,last_name,total_sum,post_code,inn,payment_method,status) Values('{contract.company_name}','{contract.first_name}','{contract.last_name}','{contract.total_sum}','{contract.post_code}','{contract.inn}','{contract.payment_method}','Выполняеться') Returning id";
            List<string[]> info = Request(request, postgres);
            foreach(string[] reader in info)
            {
                contract.id = int.Parse(reader[0]);
                return true;
            }
            return false;
        }

        public static bool CheckPartnerByName(PartnersModel partner, string postgres)
        {
            string request = $"Select * From Partners Where name = '{partner.name}'";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                partner.id = int.Parse(reader[0]);
                return true;
            }

            return false;
        }

        public static bool AddPartner(PartnersModel partner, string postgres)
        {
            if(partner.name == "")
            {
                return false;
            }

            string request = $"Insert Into Partners(name) Values('{partner.name}') Returning id;";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                partner.id = int.Parse(reader[0]);
            }
            
            return true;
        }

        public static bool CheckService(TypeOfServiceModel service, string postgres)
        {
            string request = $"Select * From Type_of_service Where platform_type = '{service.platform_type}' and partners_id = '{service.partners_id}';";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                service.id = int.Parse(reader[0]);
                service.platform_type = reader[1];
                service.partners_id = int.Parse(reader[2]);
                service.price = float.Parse(reader[3]);
                return true;
            }

            return false;
        }

        public static bool GetServiceById(TypeOfServiceModel service, string postgres)
        {
            string request = $"Select * From Type_of_service Where id = '{service.id}';";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                service.id = int.Parse(reader[0]);
                service.platform_type = reader[1];
                service.partners_id = int.Parse(reader[2]);
                service.price = float.Parse(reader[3]);
                return true;
            }

            return false;
        }

        public static bool AddService(TypeOfServiceModel service, string postgres)
        {
            if (service.platform_type == "" || service.price <= 0)
            {
                return false;
            }

            string request = $"Insert Into Type_of_Service(platform_type,partners_id,price) Values('{service.platform_type}','{service.partners_id}','{service.price}') Returning id;";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                service.id = int.Parse(reader[0]);
            }

            return true;
        }

        public static bool AddCreativeWork(CreativeWorkModel creative, string posgres)
        {
            string request = $"Insert Into Creative_work(media_plan_id,work_status,worker_id,specification,description) Values('{creative.media_plan_id}','{creative.work_status}','{creative.worker_id}','{creative.specification}','{creative.description}') Returning id;";
            List<string[]> info = Request(request, posgres);
            foreach(string[] reader in info)
            {
                creative.id = int.Parse(reader[0]);
            }

            return true;
        }

        public static void FinishMedia(MediaPlanModel media, string postgres)
        {
            string request = $"Update Media_plan set status = true Where id = '{media.id}'";
            Request(request, postgres);
        }

        //public static bool 

        /// <summary>
        /// Списки
        /// </summary>

        public static List<PositionModel> GetAllPosition(string postgres)
        {
            List<PositionModel> positions = new List<PositionModel>();

            string request = "Select * From Position";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                PositionModel position = new PositionModel();

                position.id = int.Parse(reader[0]);
                position.name = reader[1];
                position.salary = float.Parse(reader[2]);

                positions.Add(position);
            }

            return positions;
        }

        public static List<StaffModel> GetAllStaff(string postgres)
        {
            List<StaffModel> staffs = new List<StaffModel>();

            string request = "Select * From Staff";
            List<string[]> info = Request(request, postgres);

            foreach (string[] render in info)
            {
                StaffModel staff = new StaffModel();

                staff.id = int.Parse(render[0]);
                staff.first_name = render[1];
                staff.last_name = render[2];
                staff.date_of_birthday = DateTime.Parse(render[3]);
                staff.sex = render[4];
                staff.tel = render[5];
                staff.password = render[6];

                staffs.Add(staff);
            }

            return staffs;
        }

        public static List<StaffPositionModel> GetAllStaffPosition(string postgres)
        {
            List<StaffPositionModel> staffPositions = new List<StaffPositionModel>();

            string request = "Select * From Staff";
            List<string[]> info = Request(request, postgres);

            foreach (string[] render in info)
            {
                StaffPositionModel staffPosition = new StaffPositionModel();

                staffPosition.id = int.Parse(render[0]);
                staffPosition.position_id = int.Parse(render[2]);
                staffPosition.start_work = DateTime.Parse(render[3]);
                if (render[4] != "")
                    staffPosition.end_work = DateTime.Parse(render[4]);

                staffPositions.Add(staffPosition);
            }

            return staffPositions;
        }

        public static List<Staff_StaffPosition_Position> GetFullStaffInfo(string postgres)
        {
            List<Staff_StaffPosition_Position> fullStaffs = new List<Staff_StaffPosition_Position>();

            string request = "Select * From GetAllStaff();";
            List<string[]> info = Request(request, postgres);

            foreach (string[] render in info)
            {
                Staff_StaffPosition_Position s_sp_p = new Staff_StaffPosition_Position();
                StaffModel staff = new StaffModel();
                StaffPositionModel staffPosition = new StaffPositionModel();
                PositionModel position = new PositionModel();

                staff.id = int.Parse(render[0]);
                staff.first_name = render[1];
                staff.last_name = render[2];
                staff.date_of_birthday = DateTime.Parse(render[3]);
                staff.sex = render[4];
                staff.tel = render[5];
                staff.password = render[6];
                s_sp_p.staff = staff;

                staffPosition.id = int.Parse(render[7]);
                staffPosition.staff_id = staff.id;
                staffPosition.position_id = int.Parse(render[8]);
                staffPosition.start_work = DateTime.Parse(render[9]);
                if (render[10] != "")
                    staffPosition.end_work = DateTime.Parse(render[10]);
                s_sp_p.staffPosition = staffPosition;

                position.id = staffPosition.position_id;
                position.name = render[11];
                position.salary = float.Parse(render[12]);
                s_sp_p.position = position;

                fullStaffs.Add(s_sp_p);
            }

            return fullStaffs;
        }

        public static List<PreferenseListModel> GetAllPreferenceList(string postgres)
        {
            List<PreferenseListModel> preferenseLists = new List<PreferenseListModel>();

            string request = "Select * From Preference_List;";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                PreferenseListModel preference = new PreferenseListModel();

                preference.id = int.Parse(reader[0]);
                preference.client_id = int.Parse(reader[1]);
                preference.audience = reader[2];
                preference.preculiarities = reader[3];
                preference.period = int.Parse(reader[4]);
                preference.max_sum = float.Parse(reader[5]);

                preferenseLists.Add(preference);
            }

            return preferenseLists;
        }

        public static List<Client_Preferense> GetAllNotAcceptedPreferenceList(string postgres)
        {
            List<Client_Preferense> preferenseLists = new List<Client_Preferense>();

            string request = "Select * From GetPreferenceList();";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                Client_Preferense c_p = new Client_Preferense();
                c_p.preference = new PreferenseListModel();

                c_p.preference.id = int.Parse(reader[0]);
                c_p.preference.client_id = int.Parse(reader[1]);
                c_p.preference.audience = reader[2];
                c_p.preference.preculiarities = reader[3];
                c_p.preference.period = int.Parse(reader[4]);
                c_p.preference.max_sum = float.Parse(reader[5]);

                c_p.client = new ClientCompanyModel();

                c_p.client.id = int.Parse(reader[6]);
                c_p.client.company_name = reader[7];
                c_p.client.director = reader[8];
                c_p.client.city = reader[9];
                c_p.client.street = reader[10];
                c_p.client.first_name = reader[11];
                c_p.client.last_name = reader[12];
                c_p.client.tel = reader[13];
                c_p.client.email = reader[14];

                preferenseLists.Add(c_p);
            }

            return preferenseLists;
        }

        public static List<Preference_MediaPlan> GetAllAcceptedPreferenceListByStaff(StaffModel staff,string postgres)
        {
            List<Preference_MediaPlan> preferenseLists = new List<Preference_MediaPlan>();

            string request = $"Select * From GetAcceptedPreferenceListByStaff('{staff.id}') where status = 'false';";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                Preference_MediaPlan c_p = new Preference_MediaPlan();
                c_p.preference = new PreferenseListModel();

                c_p.preference.id = int.Parse(reader[0]);
                c_p.preference.audience = reader[1];
                c_p.preference.preculiarities = reader[2];
                c_p.preference.period = int.Parse(reader[3]);
                c_p.preference.max_sum = float.Parse(reader[4]);

                MediaPlanModel mediaPlan = new MediaPlanModel();
                mediaPlan.id = int.Parse(reader[5]);
                mediaPlan.preferences_list_id = c_p.preference.id;
                mediaPlan.type_of_service_id = int.Parse(reader[6]);
                mediaPlan.staff_id = int.Parse(reader[7]);
                mediaPlan.broadcast_time = int.Parse(reader[8]);
                mediaPlan.price = float.Parse(reader[9]);
                mediaPlan.status = bool.Parse(reader[10]);
                c_p.mediaPlan = mediaPlan;

                preferenseLists.Add(c_p);
            }

            return preferenseLists;
        }

        public static List<PreferenseListModel> GetAllPreferencListClient(ClientCompanyModel client, string postgres)
        {
            List<PreferenseListModel> preferenseLists = new List<PreferenseListModel>();

            string request = $"Select * From Preference_List Where client_id = '{client.id}';";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                PreferenseListModel preference = new PreferenseListModel();

                preference.id = int.Parse(reader[0]);
                preference.client_id = int.Parse(reader[1]);
                preference.audience = reader[2];
                preference.preculiarities = reader[3];
                preference.period = int.Parse(reader[4]);
                preference.max_sum = float.Parse(reader[5]);

                preferenseLists.Add(preference);
            }

            return preferenseLists;
        }

        public static List<Preference_MediaPlan> GetFullPreferenceListAccepted(PreferenseListModel preferense, string postgreas)
        {
            List<Preference_MediaPlan> preference_MediaPlans = new List<Preference_MediaPlan>();

            string request = $"Select * From Getacceptedpreferencelist('{preferense.client_id}');";

            List<string[]> info = Request(request, postgreas);
            foreach(string[] reader in info)
            {
                Preference_MediaPlan p_mp = new Preference_MediaPlan();
                PreferenseListModel p = new PreferenseListModel();
                p.id = int.Parse(reader[0]);
                p.client_id = preferense.client_id;
                p.audience = reader[1];
                p.preculiarities = reader[2];
                p.period = int.Parse(reader[3]);
                p.max_sum = float.Parse(reader[4]);
                p_mp.preference = p;

                MediaPlanModel mediaPlan = new MediaPlanModel();
                mediaPlan.id = int.Parse(reader[5]);
                mediaPlan.preferences_list_id = p.id;
                mediaPlan.type_of_service_id = int.Parse(reader[6]);
                mediaPlan.staff_id = int.Parse(reader[7]);
                mediaPlan.broadcast_time = int.Parse(reader[8]);
                mediaPlan.price = float.Parse(reader[9]);
                mediaPlan.status = bool.Parse(reader[10]);
                p_mp.mediaPlan = mediaPlan;

                preference_MediaPlans.Add(p_mp);
            }

            foreach(Preference_MediaPlan p in preference_MediaPlans)
            {
                p.before = new BeforeTheContractModel();
                p.before.media_plan_id = p.mediaPlan.id;
                if (!CheckBeforeTheContractByMediaPlan(p.before, postgreas))
                {
                    p.before = null;
                }
                else
                {
                    p.contract = new ContractModel();
                    CheckControactByBefore(p.before, p.contract, postgreas);
                }
            }

            return preference_MediaPlans;
        }

        public static List<Partners_Services> GetFullPartnersService(string postgres)
        {
            List<Partners_Services> partners_Services = new List<Partners_Services>();

            string request = $"Select * From Partners";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                Partners_Services p_s = new Partners_Services();

                p_s.partners = new PartnersModel();
                p_s.partners.id = int.Parse(reader[0]);
                p_s.partners.name = reader[1];

                partners_Services.Add(p_s);
            }

            foreach(Partners_Services p in partners_Services)
            {
                p.services = GetAllService(p.partners,postgres);
            }

            return partners_Services;
        }

        public static List<TypeOfServiceModel> GetAllService(PartnersModel partners, string postgres)
        {
            List<TypeOfServiceModel> services = new List<TypeOfServiceModel>();

            string request = $"Select * From Type_of_Service where partners_id = '{partners.id}'";

            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                TypeOfServiceModel s = new TypeOfServiceModel();
                s.id = int.Parse(reader[0]);
                s.platform_type = reader[1];
                s.partners_id = int.Parse(reader[2]);
                s.price = float.Parse(reader[3]);

                services.Add(s);
            }

            return services;
        }

        public static List<CreativeWorkModel> GetAllCreativeWorkingByMedia(MediaPlanModel media, string postgres)
        {
            List<CreativeWorkModel> creativeWorks = new List<CreativeWorkModel>();

            string request = $"Select * From Creative_work where media_plan_id = '{media.id}';";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                CreativeWorkModel creative = new CreativeWorkModel();
                creative.id = int.Parse(reader[0]);
                creative.media_plan_id = int.Parse(reader[1]);
                creative.work_status = bool.Parse(reader[2]);
                creative.worker_id = int.Parse(reader[3]);
                creative.specification = reader[4];
                creative.description = reader[5];

                creativeWorks.Add(creative);
            }

            return creativeWorks;
        }

        public static bool GetCreativeWorkingByStaff(CreativeWorkModel creativeWork, string postgres)
        {
            string request = $"Select * From Creative_work where worker_id = '{creativeWork.worker_id}' and work_status = 'false';";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                creativeWork.id = int.Parse(reader[0]);
                creativeWork.media_plan_id = int.Parse(reader[1]);
                creativeWork.work_status = bool.Parse(reader[2]);
                creativeWork.worker_id = int.Parse(reader[3]);
                creativeWork.specification = reader[4];
                creativeWork.description = reader[5];
                return true;
            }

            return false;
        }

        public static List<StaffModel> GetAllFreeStaff(string postgres)
        {
            List<StaffModel> staffs = new List<StaffModel>();

            string request = $"Select GetAllFreeStaff();";
            List<string[]> info = Request(request, postgres);

            foreach(string[] reader in info)
            {
                StaffModel staff = new StaffModel();
                staff.id = int.Parse(reader[0]);

                staffs.Add(staff);
            }

            foreach(StaffModel s in staffs)
            {
                GetStaffById(s, postgres);
            }

            return staffs;
        }

        public static List<StaffModel> GetAllBuysStaff(MediaPlanModel media, string postgres)
        {
            List<StaffModel> staffs = new List<StaffModel>();

            string request = $"Select GetAllBusyStaff('{media.id}');";
            List<string[]> info = Request(request, postgres);

            foreach (string[] reader in info)
            {
                StaffModel staff = new StaffModel();
                staff.id = int.Parse(reader[0]);

                staffs.Add(staff);
            }

            foreach (StaffModel s in staffs)
            {
                GetStaffById(s, postgres);
            }

            return staffs;
        }

        private static List<string[]> Request(string request,string postgres)
        {
            List<string[]> info = new List<string[]>();
            DBConect db = new DBConect(postgres);
            db.OpenConnection();
            NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter();
            NpgsqlCommand command = new NpgsqlCommand(request, db.getConnection());
            npgsqlDataAdapter.SelectCommand = command;
            NpgsqlDataReader Reader = command.ExecuteReader();

            while (Reader.Read())
            {
                if (Reader[0].ToString() == "")
                    break;

                string[] value = new string[Reader.FieldCount];
                for(int i = 0; i < value.Length; i++)
                {
                    value[i] = Reader[i].ToString();
                }

                info.Add(value);
            }
            db.CloseConnection();

            return info;
        }
    }
}