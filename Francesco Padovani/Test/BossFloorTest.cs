using System;
using System.Drawing;
using Xunit;
using mapandtiles;

namespace FrancescoPadovani

{
   public class BossFloorTest
    {
        [Fact]
        public void TestBossFloor() 
        {
            BossFloor bf = new BossFloor(1, 2000, 1000, 1980, 1080);
            Assert.Equal(bf.GetScreenh(), bf.GetHeight());
            Assert.Equal(1080, bf.GetHeight());
            Assert.Equal(1980, bf.GetWidth());
            Assert.False(bf.GetMap()[new Point(10, 10)].IsExit());
            bf.ExitCreate(new Point(10, 10));
            Assert.True(bf.GetMap()[new Point(10, 10)].IsExit());
            Assert.Equal(0, bf.GetOffsetX());
            bf.MoveCam(10, 10);
            Assert.Equal(0, bf.GetOffsetX());

        }
    }
}
