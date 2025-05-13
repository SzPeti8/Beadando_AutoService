using AutoService.UI.Services.Implementation;
using AutoService.Shared;


namespace Car.UI.Tests
{
    public class WorkHourEstimationServiceTests
    {
        public static IEnumerable<object[]> Generate_AllCategoriesOthersConstantTestData()
        {
            yield return [
                new Work
                {
                    


                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 3,1, 1),
                    FaultSeverity = 1,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Motor,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 3,1, 1),
                    FaultSeverity = 1,
                },
                8d * 0.5d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Futomu,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 3,1, 1),
                    FaultSeverity = 1,
                },
                6d * 0.5d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Fekberendezes,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 3,1, 1),
                    FaultSeverity = 1,
                },
                4d * 0.5d * 0.2d
            ];
        }

        public static IEnumerable<object[]> Generate_AllDateOfMakesOthersConstantTestData()
        {
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 0,1, 1),
                    FaultSeverity = 1,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 4,1, 1),
                    FaultSeverity = 1,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 5,1, 1),
                    FaultSeverity = 1,
                },
                3d * 1.0d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 9,1, 1),
                    FaultSeverity = 1,
                },
                3d * 1.0d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 10,1, 1),
                    FaultSeverity = 1,
                },
                3d * 1.5d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 19,1, 1),
                    FaultSeverity = 1,
                },
                3d * 1.5d * 0.2d
            ];
            yield return [
                new Work
                {
                   WorkType= WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 20,1, 1),
                    FaultSeverity = 1,
                },
                3d * 2.0d * 0.2d
            ];
        }

        public static IEnumerable<object[]> Generate_AllSeveritiesOthersConstantTestData()
        {
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 1,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 2,
                },
                3d * 0.5d * 0.2d
            ];
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 3,
                },
                3d * 0.5d * 0.4d
            ];
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 4,
                },
                3d * 0.5d * 0.4d
            ];
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 5,
                },
                3d * 0.5d * 0.6d
            ];
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 7,
                },
                3d * 0.5d * 0.6d
            ];
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 8,
                },
                3d * 0.5d * 0.8d
            ];
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 9,
                },
                3d * 0.5d * 0.8d
            ];
            yield return [
                new Work
                {
                    WorkType = WorkTypeEnum.Karosszeria,
                    DateOfMake = new DateOnly(DateTime.Now.Year - 1,1, 1),
                    FaultSeverity = 10,
                },
                3d * 0.5d * 1.0d
            ];
        }

        [Theory]
        [MemberData(nameof(Generate_AllCategoriesOthersConstantTestData))]
        public void GetEstimation_AllCategoriesOthersConstant_ReturnsCorrectEstimation(Work work, double expected)
        {
            WorkHourEstimationService service = new WorkHourEstimationService();

            double result = service.GetWorkHourEstimation(work);

            Assert.Equal(expected, result, 0.1d);
        }

        [Theory]
        [MemberData(nameof(Generate_AllDateOfMakesOthersConstantTestData))]
        public void GetEstimation_AllDateOfMakesOthersConstant_ReturnsCorrectEstimation(Work work, double expected)
        {
            WorkHourEstimationService service = new WorkHourEstimationService();

            double result = service.GetWorkHourEstimation(work);

            Assert.Equal(expected, result, 0.1d);
        }

        [Theory]
        [MemberData(nameof(Generate_AllSeveritiesOthersConstantTestData))]
        public void GetEstimation_AllSeveritiesOthersConstant_ReturnsCorrectEstimation(Work work, double expected)
        {
            WorkHourEstimationService service = new WorkHourEstimationService();

            double result = service.GetWorkHourEstimation(work);

            Assert.Equal(expected, result, 0.1d);
        }
    }
}