using ColossalFramework.UI;
using Klyte.Commons.Utils;
using UnityEngine;

namespace Klyte.Commons.UI
{
    public class TLMAgesChartPanel : MonoBehaviour
    {
        private UIPanel agesChartPanel;
        private UIRadialChartAge agesChart;
        private Transform parent => transform.parent;

        public void Awake()
        {
            createLineCharts();
        }

        public void SetValues(int[] values)
        {
            agesChart.SetValues(values);
        }

        private void createLineCharts()
        {
            KlyteUtils.createUIElement(out agesChartPanel, parent);
            agesChartPanel.relativePosition = new Vector3(450f, 45f);
            agesChartPanel.width = 140;
            agesChartPanel.height = 70;
            agesChartPanel.name = "AgesChartPanel";
            agesChartPanel.autoLayout = false;
            agesChartPanel.useCenter = true;
            agesChartPanel.wrapLayout = false;

            KlyteUtils.createUIElement(out UIPanel pieLegendPanel, agesChartPanel.transform);
            pieLegendPanel.relativePosition = new Vector3(70f, 0f);
            pieLegendPanel.width = 70;
            pieLegendPanel.height = 70;
            pieLegendPanel.name = "AgesChartLegendPanel";
            pieLegendPanel.wrapLayout = false;
            pieLegendPanel.autoLayout = false;
            pieLegendPanel.useCenter = true;

            KlyteUtils.createUIElement(out agesChart, agesChartPanel.transform);
            agesChart.spriteName = "PieChartWhiteBg";
            agesChart.tooltipLocaleID = "ZONEDBUILDING_AGECHART";
            agesChart.relativePosition = new Vector3(0, 0);
            agesChart.width = 70;
            agesChart.height = 70;
            agesChart.name = "AgesChart";
            Color32 criancaColor = new Color32(254, 218, 155, 255);
            Color32 adolescenteColor = new Color32(205, 239, 145, 255);
            Color32 jovemColor = new Color32(189, 206, 235, 255);
            Color32 adultoColor = new Color32(255, 162, 162, 255);
            Color32 idosoColor = new Color32(100, 224, 206, 255);
            int y = 0;
            criaFatiaELegenda(criancaColor, agesChart, pieLegendPanel, "ZONEDBUILDING_CHILDREN", 14 * y++);
            criaFatiaELegenda(adolescenteColor, agesChart, pieLegendPanel, "ZONEDBUILDING_TEENS", 14 * y++);
            criaFatiaELegenda(jovemColor, agesChart, pieLegendPanel, "ZONEDBUILDING_YOUNGS", 14 * y++);
            criaFatiaELegenda(adultoColor, agesChart, pieLegendPanel, "ZONEDBUILDING_ADULTS", 14 * y++);
            criaFatiaELegenda(idosoColor, agesChart, pieLegendPanel, "ZONEDBUILDING_SENIORS", 14 * y++);
        }
        private void criaFatiaELegenda(Color c, UIRadialChartAge chart, UIPanel legendPanel, string localeID, float offsetY)
        {
            chart.AddSlice(c, c);
            KlyteUtils.createUIElement(out UIPanel legendItemContainer, legendPanel.transform);
            legendItemContainer.width = legendPanel.width;
            legendItemContainer.relativePosition = new Vector3(0f, offsetY);
            legendItemContainer.name = "LegendItem";
            legendItemContainer.autoLayout = false;
            legendItemContainer.useCenter = true;
            legendItemContainer.wrapLayout = false;
            legendItemContainer.height = 20;
            KlyteUtils.createUIElement(out UILabel legendColor, legendItemContainer.transform);
            legendColor.backgroundSprite = "EmptySprite";
            legendColor.width = 10;
            legendColor.height = 10;
            legendColor.relativePosition = new Vector3(0, 0);
            legendColor.color = c;
            KlyteUtils.createUIElement(out UILabel legendName, legendItemContainer.transform);
            legendName.textAlignment = UIHorizontalAlignment.Right;
            legendName.width = legendItemContainer.width - 10;
            legendName.localeID = localeID;
            legendName.textScale = 0.6f;
            legendName.relativePosition = new Vector3(15f, 2f);
            legendName.verticalAlignment = UIVerticalAlignment.Middle;
        }
    }
}

