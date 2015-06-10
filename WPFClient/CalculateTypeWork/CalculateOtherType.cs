using System.Windows;
using Data.Entity.Enum;

namespace WPFClient.CalculateTypeWork
{
    public static class CalculateOtherType
    {
        public static double [] Calculate(TypeWork selectedTypeWork, SubTypeWork selectedSubTypeWork, int countStudB, int countStudC, int countHoursExam, int countAspDok, int t, int n, int g, int gk, int dg, int d)
        {
            var item = new double[2];
            double totalBudget = 0;
            double totalContract = 0;

            switch (selectedTypeWork)
            {
                case TypeWork.Індивідуальні_заняття:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.зі_студентами:
                                {
                                    //
                                } break;

                            case SubTypeWork.з_магістрами:
                                {
                                    totalBudget = 0.2 * n * countStudB / 15;
                                    totalContract = 0.2 * n * countStudC / 15;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }

                    }
                    break;

                case TypeWork.Керівництво_практикою:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.навчальною:
                                {
                                    totalBudget = 30 * t * g;
                                    totalContract = 30 * t * gk;
                                } break;
                            case SubTypeWork.виробничою:
                                {
                                    totalBudget = 10 * t * g / 2;
                                    totalContract = 10 * t * gk / 2;
                                } break;
                            case SubTypeWork.проект_технол:
                                {
                                    totalBudget = 10 * t * g;
                                    totalContract = 10 * t * gk;
                                } break;
                            case SubTypeWork.переддиплом:
                                {
                                    totalBudget = 1 * t * countStudB;
                                    totalContract = 1 * t * countStudC;
                                } break;
                            case SubTypeWork.науков_дослід:
                                {
                                    totalBudget = 1 * t * countStudB;
                                    totalContract = 1 * t * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Керівництво_атестац_роб:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 17 * countStudB;
                                    totalContract = 17 * countStudC;
                                } break;

                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 19.5 * countStudB;
                                    totalContract = 19.5 * countStudC;
                                } break;

                            case SubTypeWork.магістрів:
                                {
                                    totalBudget = 29 * countStudB;
                                    totalContract = 29 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }

                    } break;

                case TypeWork.Консультування_атестац_роб:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 4 * countStudB;
                                    totalContract = 4 * countStudC;
                                } break;
                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 4 * countStudB;
                                    totalContract = 4 * countStudC;
                                } break;
                            case SubTypeWork.магістрів:
                                {
                                    totalBudget = 5 * countStudB;
                                    totalContract = 5 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Рецензування_атестац_роб:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 2 * countStudB;
                                    totalContract = 2 * countStudC;
                                } break;
                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 3 * countStudB;
                                    totalContract = 3 * countStudC;
                                } break;
                            case SubTypeWork.магістрів:
                                {
                                    totalBudget = 4 * countStudB;
                                    totalContract = 4 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Консультування_перед_держ_екзам:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 2 * g * dg;
                                    totalContract = 2 * gk * dg;
                                } break;
                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 2 * g * dg;
                                    totalContract = 2 * gk * dg;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Роб_в_ДЕК_захист_дипл:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.бакалаврів:
                                {
                                    totalBudget = 0.5 * d * countStudB;
                                    totalContract = 0.5 * d * countStudB;
                                } break;
                            case SubTypeWork.спеціалістів:
                                {
                                    totalBudget = 0.5 * d * countStudB;
                                    totalContract = 0.5 * d * countStudB;
                                } break;
                            case SubTypeWork.магістрів:
                                {
                                    totalBudget = 0.5 * d * countStudB;
                                    totalContract = 0.5 * d * countStudB;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;
                case TypeWork.Роб_в_ДЕК_екзам_усн:
                    {
                        if (selectedSubTypeWork == SubTypeWork.бакалаврів)
                        {
                            totalBudget = 0.5 * d * countStudB;
                            totalContract = 0.5 * d * countStudB;
                        }
                    } break;
                case TypeWork.Роб_в_ДЕК_екзам_пис:
                    {
                        if (selectedSubTypeWork == SubTypeWork.бакалаврів)
                        {
                            totalBudget = 4 * d * g + 0.5 * countStudB;
                            totalContract = 4 * d * gk + 0.5 * countStudB;
                        }
                    } break;
                case TypeWork.Роб_в_ДЕК_екзам:
                    {
                        if (selectedSubTypeWork == SubTypeWork.спеціалістів)
                        {
                            totalBudget = countHoursExam * countStudB;
                            totalContract = countHoursExam * countStudC;
                        }
                    } break;

                case TypeWork.Керівництво:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.аспірантами:
                                {
                                    totalBudget = countAspDok * countStudB;
                                    totalContract = countAspDok * countStudC;
                                } break;
                            case SubTypeWork.здобув_стаж:
                                {
                                    totalBudget = 12.5 * countStudB;
                                    totalContract = 12.5 * countStudC;
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Заняття_з_аспірантами:
                    {
                        switch (selectedSubTypeWork)
                        {
                            case SubTypeWork.лекції:
                                {
                                    //
                                } break;
                            case SubTypeWork.семінари_практич_зан:
                                {
                                    //
                                } break;
                            case SubTypeWork.консульт_реценз_екз:
                                {
                                    //
                                } break;
                            default:
                                {
                                    MessageBox.Show("Виберіть значення в полі \"Під тип\" !");
                                } break;
                        }
                    } break;

                case TypeWork.Консультування_докторантів:
                    {
                        totalBudget = countAspDok * countStudB;
                        totalContract = countAspDok * countStudC;
                    } break;

                default:
                    {
                        MessageBox.Show("Виберіть значення в полі вид роботи !");

                    } break;
            }

            item[0] = totalBudget;
            item[1] = totalContract;

            return item;
        }
    }
}
