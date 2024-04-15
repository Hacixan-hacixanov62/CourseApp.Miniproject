using Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Service.Helpers.Constans;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using System.Data;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp.Miniproject2.Controllers
{
    public class GroupControllers
    {
        private readonly IGroupService _groupService;
        private readonly IEducationService _educationService;
       

        public GroupControllers()
        {
            _groupService = new GroupService();
            _educationService = new EducationService();
           
        }

        public async Task GroupCreateAsync()
        {

            ConsoleColor.Magenta.WriteConsole("Add Group name: ");
        GroupName: string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto GroupName;
            }

            //if (name.Any(m => m.Name == name))
            //{
            //    ConsoleColor.Red.WriteConsole("Please add new name ");
            //    goto GroupName;
            //}

            if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
            {
                ConsoleColor.Red.WriteConsole("Format is wrong");
                goto GroupName;
            }

            //if (name.Length < 3)
            //{
            //    ConsoleColor.Red.WriteConsole(" Name or Surname must not be less than three letters ");
            //    goto GroupName;
            //}


            ConsoleColor.Magenta.WriteConsole("Add Education id: ");
        EducationId: string idStr = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto EducationId;
            }

            int id;
            bool isCorrectFormat =int.TryParse(idStr, out id);

            if (isCorrectFormat)

            {


                if (!int.TryParse(idStr, out id))
                {

                    ConsoleColor.Red.WriteConsole(ResponseMessages.InvalidCapacityFormat + ". Please try again:");
                    goto EducationId;
                }
                Domain.Models.Education addedGroup;

                try
                {
                    addedGroup = await _educationService.GetByIdAsync(id);
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole("There is no group with specified id. Please try again:");
                    goto EducationId;
                }



                ConsoleColor.Magenta.WriteConsole("Add Group capacity : ");
            GroupCapacity: string capacityStr = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(capacityStr))
                {
                    ConsoleColor.Red.WriteConsole("Input can't be empty ");
                    goto GroupCapacity;
                }

                int capacity;

                if (!int.TryParse(capacityStr, out capacity))
                {
                    ConsoleColor.Red.WriteConsole(ResponseMessages.InvalidCapacityFormat + ". Please try again:");
                    goto GroupCapacity;
                }



             

                try
                {
                    DateTime time = DateTime.Now;

                    await _groupService.CreateAsync(new Domain.Models.Group() { Name = name.Trim().ToLower(), Capacity = capacity, EducationId = id, CreatedDate = time });
                    ConsoleColor.Green.WriteConsole("Data successfully added");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole("Group can have maximum 5 students. Please choose another group:");
                }



                //if()

                //    ConsoleColor.Red.WriteConsole("There is no group with specified id. Please try again:");
                //goto EducationId;
            }

        }

        public async Task GroupDeleteAsync()
        {

            ConsoleColor.Cyan.WriteConsole("Add group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    await _groupService.DeleteAsync(id);
                    ConsoleColor.Green.WriteConsole("Data successfully deleted");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);

                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }
        }

        public async Task GroupUpdateAsync()
        {
            bool isInputValid = false;

            while (!isInputValid)
            {
                try
                {
                    ConsoleColor.Cyan.WriteConsole("Please write Group ID:");

                uId: string idStr = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(idStr))
                    {
                        Console.WriteLine("ID can't be empty. Please write again.");
                        goto uId;
                    }

                    if (!int.TryParse(idStr, out int id))
                    {
                        Console.WriteLine("Format is wrong. Please write correctly.");
                        goto uId;
                    }

                    var existingGroup = await _groupService.GetByIdAsync(id);
                    if (existingGroup == null)
                    {
                        Console.WriteLine("Group not found");
                        goto uId;
                    }

                    ConsoleColor.Cyan.WriteConsole("Please write new group name:");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        name = existingGroup.Name;
                    }
                    else if (!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$"))
                    {
                        ConsoleColor.Red.WriteConsole("Input is not correct, please try again.");
                        continue;
                    }

                    ConsoleColor.Cyan.WriteConsole("Please write new group capacity :");
                    string capacityStr = Console.ReadLine();
                    int capacity;
                    if (string.IsNullOrWhiteSpace(capacityStr))
                    {
                        capacity = existingGroup.Capacity;
                    }
                    else if (!int.TryParse(capacityStr, out capacity))
                    {
                        ConsoleColor.Red.WriteConsole("Input is not correct, please try again.");
                        continue;
                    }

                    ConsoleColor.Cyan.WriteConsole("Please write new education ID:");
                    string eduIdStr = Console.ReadLine();
                    int eduId;
                    if (string.IsNullOrWhiteSpace(eduIdStr))
                    {
                        eduId = existingGroup.EducationId;
                    }
                    else if (!int.TryParse(eduIdStr, out eduId))
                    {
                        ConsoleColor.Red.WriteConsole("Input is not correct, please try again.");
                        continue;
                    }

                    existingGroup.Name = name;
                    existingGroup.Capacity = capacity;
                    existingGroup.EducationId = eduId;

                    await _groupService.UpdateAsync(existingGroup);
                    Console.WriteLine("Group successfully updated.");
                    isInputValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    
            

        public async Task GroupGetAllAsync()
        {
            var response = await _groupService.GetAllAsync();

            foreach (var item in response)
            {
                string data = $"Id: {item.Id}, Group name : {item.Name}, Group capacity : {item.Capacity}  ";

                Console.WriteLine(data);
            }
        }

        public async Task GroupSearchAsync()
        {

        SearchAsync: ConsoleColor.White.WriteConsole("Add search text: ");

        Name: string searchText = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto SearchAsync;
            }
            try
            {
                var response = await _groupService.SearchAsync(searchText);


                if (response.Count == 0)
                {
                    ConsoleColor.Red.WriteConsole(" Name  notfaound ");
                }

                foreach (var item in response)
                {
                    string data = $"Id: {item.Id},Group name : {item.Name}, Group capacity : {item.Capacity} ";
                    Console.WriteLine(data);
                }

            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto SearchAsync;
            }
        }
    

        public async Task GroupGetByIdAsync()
        {

            ConsoleColor.Cyan.WriteConsole("Add Id: ");
        Id: string idStr = Console.ReadLine();
            int id;

            bool isCorrectIdFormat = int.TryParse(idStr, out id);

            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Id;
            }
            try
            {

                var response = await _groupService.GetByIdAsync(id);

                string data = $"Id: {response.Id}, Education name : {response.Name} , Group capacity : {response.Capacity}";
                Console.WriteLine(data);

            }
            catch (Exception)
            {
                ConsoleColor.Red.WriteConsole(" Id notfound ");
            }
        }

        public async Task GroupFilterByEducationNameAsync()
        {
          
            ConsoleColor.White.WriteConsole("Add Education name ");
        Education: string name = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can not empty ");
                goto Education;
            }
            else
            {
                try
                {

                    var response = await _groupService.FilterByEducationNameAsync(name);

                    if (response.Count !=0)
                    {
                        foreach(var item in response)
                        {
                            string data = $"Group name : {item.Name}, Education : {item.Education.Name}";
                            await Console.Out.WriteLineAsync(data);
                        }
                    }
                    else
                    {
                        ConsoleColor.Red.WriteConsole("This study could not be found  ");
                        goto Education;
                    }

                }
                catch(Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Education;
                }
            }

        }

        public async Task GroupGetAllWithEducationIdAsync()
        {
            ConsoleColor.Cyan.WriteConsole("Add Group education id: ");
        Id: string idStr = Console.ReadLine();
            int id;
            

            bool isCorrectIdFormat = int.TryParse(idStr, out id);


            if (string.IsNullOrWhiteSpace(idStr))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty ");
                goto Id;
            }

            if (isCorrectIdFormat)
            {
                try
                { 

                    List<Domain.Models.Group> response = await  _groupService.GetAllWithEducationIdAsync(id);
                     
                    if (response.Count == 0)
                    {
                        ConsoleColor.Red.WriteConsole(" Group educatio Id notfound ");
                        return;

                    }
                    else
                    {

                        foreach (var item in response)
                        {
                            string data = $" Id: {item.Id}, Group name : {item.Name}, Group Capacity : {item.Capacity}, Group EducationId : {item.EducationId}";
                            Console.WriteLine(data);
                        }
                    }


                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }

            }
            else
            {
                ConsoleColor.Red.WriteConsole(" Group education id notfound , please corect group id");
                goto Id;
            }

        }


        public async Task GroupSortWithCapacityAsync()
        {
            try
            {
                ConsoleColor.Cyan.WriteConsole(" Choose sort capacity: ");
                 string test = Console.ReadLine();
                var datas = await _groupService.SortWithCapacityAsync(test);

                foreach (var data in datas)
                {
                  
                    Console.WriteLine("Name" + data.Name + "CreateDate" + data.Capacity);

                }

            }
            catch(Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }

        

    }
}
