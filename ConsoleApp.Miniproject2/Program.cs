

using ConsoleApp.Miniproject2.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;

EducationControllers educationControllers = new ();
GroupControllers groupControllers = new  ();



ConsoleColor.Yellow.WriteConsole("WELCOME PB-101");


while (true)
{
    GetMenues();

Operation: string operationStr = Console.ReadLine();


    int operation;

    bool isCorrectOpreationFormat = int.TryParse(operationStr, out operation);
    if (isCorrectOpreationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.EducationCreateAsync:
               await educationControllers.EducationCreateAsync();
                break;

            case (int)OperationType.EducationUpdateAsync:
               await educationControllers.EducationUpdateAsync();
                break;

            case (int)OperationType.EducationDeleteAsync:
               await educationControllers.EducationDeleteAsync();
                break;

            case (int)OperationType.EducationGetAllAsync:
               await educationControllers.EducationGetAllAsync();
                break;

            case (int)OperationType.EducationGetAllWithGroupsAsync:
               await educationControllers.EducationGetAllWithGroupsAsync();
                break;

            case (int)OperationType.EducationGetByIdAsync:
               await educationControllers.EducationGetByIdAsync();
                break;


            case (int)OperationType.EducationSearchAsync:
               await educationControllers.EducationSearchAsync();
                break;


            case (int)OperationType.EducationSortWithCreatedDateAsync:
               await educationControllers.EducationSortWithCreatedDateAsync();
                break;


            case (int)OperationType.GroupCreateAsync:
               await groupControllers.GroupCreateAsync();
                break;

            case (int)OperationType.GroupDeleteAsync:
               await groupControllers.GroupDeleteAsync();
                break;


            case (int)OperationType.GroupUpdateAsync:
                await groupControllers.GroupUpdateAsync();
                break;


            case (int)OperationType.GroupGetAllAsync:
               await groupControllers.GroupGetAllAsync();
                break;

            case (int)OperationType.GroupSearchAsync:
               await groupControllers.GroupSearchAsync();
                break;

            case (int)OperationType.GroupGetByIdAsync:
               await groupControllers.GroupGetByIdAsync();
                break;


            case (int)OperationType.GroupFilterByEducationNameAsync:
               await groupControllers.GroupFilterByEducationNameAsync();
                break;

            case (int)OperationType.GroupGetAllWithEducationIdAsync:
              await  groupControllers.GroupGetAllWithEducationIdAsync();
                break;

            case (int)OperationType.GroupSortWithCapacityAsync:
               await groupControllers. GroupSortWithCapacityAsync();
                break;


            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong, please choose again");
                goto Operation;

        }

    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong, please add operation again");
        goto Operation;
    }



}

void GetMenues()
{

    ConsoleColor.Cyan.WriteConsole("\nSelect one operation:\n\n" +

          " Education operations                  Group operations\n" +

        " 1. EducationCreateAsync                   9. GroupCreateAsync\n" +
        " 2. EducationUpdateAsync                   10.GroupUpdateAsync\n" +
        " 3. EducationDeleteAsync                   11.GroupDeleteAsync\n" +
        " 4. EducationGetAllAsync                   12.GroupGetAllAsync\n" +
        " 5. EducationGetAllWithGroupsAsync         13.GroupSearchAsync\n" +
        " 6. EducationGetByIdAsync                  14.GroupGetByIdAsync\n" +
        " 7. EducationSearchAsync                   15.GroupFilterByEducationNameAsync\n" +
        " 8. EducationSortWithCreatedDateAsync      16.GroupGetAllWithEducationIdAsync\n" +
        "                                           17.GroupSortWithCapacityAsync ");

}

 
         
        
       
        
        
        
        
        
     