namespace Service.Helpers.Enums
{
    public enum OperationType
    {
        EducationCreateAsync = 1,
        EducationUpdateAsync ,
        EducationDeleteAsync ,
        EducationGetAllAsync,
        EducationGetAllWithGroupsAsync,
        EducationGetByIdAsync,
        EducationSearchAsync,
        EducationSortWithCreatedDateAsync,
        GroupCreateAsync,
        GroupUpdateAsync,
        GroupDeleteAsync,
        GroupGetAllAsync,
        GroupSearchAsync,
        GroupGetByIdAsync,
        GroupFilterByEducationNameAsync,
        GroupGetAllWithEducationIdAsync,
        GroupSortWithCapacityAsync,

    }
}
