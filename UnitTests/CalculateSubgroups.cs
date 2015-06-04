using System;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CalculateSubgroups
    {

        public int GetBudgetSubGroupsCount(int countStudentBudget)
        {
            int countSubGroupBudget;

            if (countStudentBudget % 15 >= 10)
                countSubGroupBudget = (countStudentBudget / 15) + 1;
            else
            {
                countSubGroupBudget = (countStudentBudget / 15) < 1 ? 1 : (countStudentBudget / 15);
                if (countStudentBudget / countSubGroupBudget >= 19)
                    countSubGroupBudget++;
            }

            return countSubGroupBudget;
        }

        [Test]
        public void BudgetSubGroupsCountTest()
        {
            Assert.AreEqual(3, GetBudgetSubGroupsCount(54));
            Assert.AreEqual(11, GetBudgetSubGroupsCount(167));
            Assert.AreEqual(2, GetBudgetSubGroupsCount(24));
            Assert.AreEqual(1, GetBudgetSubGroupsCount(5));
        }


        public int GetContractSubGroupsCount(int countStudentContract)
        {
            int countSubGroupContract;

            if (countStudentContract % 15 >= 10)
                countSubGroupContract = (countStudentContract / 15) + 1;
            else
            {
                countSubGroupContract = (countStudentContract / 15) < 1 ? 1 : (countStudentContract / 15);

                if (countStudentContract / countSubGroupContract >= 19)
                    countSubGroupContract++;
            }

            return countSubGroupContract;
        }

        [Test]
        public void ContractSubGroupsCountTest()
        {
            Assert.AreEqual(5, GetContractSubGroupsCount(73));
            Assert.AreEqual(2, GetContractSubGroupsCount(19));
            Assert.AreEqual(2, GetContractSubGroupsCount(26));
            Assert.AreEqual(1, GetContractSubGroupsCount(5));
        }

    }

}
