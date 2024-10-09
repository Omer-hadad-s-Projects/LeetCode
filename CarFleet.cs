//https://leetcode.com/problems/car-fleet/submissions/1417350027/

using NUnit.Framework;

namespace LeetCode
{
    public class CarFleet
    {
        public int CarFleetSolution(int target, int[] position, int[] speed)
        {
            int n = position.Length;
            var cars = new (int position, float time)[n];

            for (int i = 0; i < n; i++)
            {
                float timeToTarget = (float)(target - position[i]) / speed[i];
                cars[i] = (position[i], timeToTarget);
            }
            Array.Sort(cars, (a, b) => b.position.CompareTo(a.position));

            int fleets = 0;
            float lastFleetTime = 0;
            
            foreach (var car in cars)
            {
                if (car.time > lastFleetTime)
                {
                    fleets++;
                    lastFleetTime = car.time;
                }
            }

            return fleets;
        }
        
        [Test]
        public void TestExample1()
        {
            int target = 12;
            int[] position = { 10, 8, 0, 5, 3 };
            int[] speed = { 2, 4, 1, 1, 3 };
            int result = CarFleetSolution(target, position, speed);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void TestExample2()
        {
            int target = 10;
            int[] position = [3];
            int[] speed = [3];
            int result = CarFleetSolution(target, position, speed);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestExample3()
        {
            int target = 100;
            int[] position = [0, 2, 4];
            int[] speed = [4, 2, 1];
            int result = CarFleetSolution(target, position, speed);
            Assert.AreEqual(1, result);
        }
        
    }
}