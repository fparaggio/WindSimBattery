<?xml version="1.0" standalone="yes"?>
<ProjectParameters xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="ProjectParameters.xsd">
  <WindSim>
    <Version>510</Version>
    <ProjectType>wind_energy_micro</ProjectType>
    <Customer />
    <LicenseHolder>Microsoft</LicenseHolder>
  </WindSim>
  <DTM LastChanged="2013-01-14T14:01:52.3602406+01:00">
    <Type>1</Type>
    <CoordSys>3</CoordSys>
    <XMin>0</XMin>
    <XMax>50</XMax>
    <YMin>0</YMin>
    <YMax>50</YMax>
    <Elongation>1</Elongation>
    <Roughness>0</Roughness>
    <GenerateCFDModel>true</GenerateCFDModel>
    <GenerateVTF>true</GenerateVTF>
    <TextureFile />
    <GenerateGLViewFine>false</GenerateGLViewFine>
    <SmoothingType>0</SmoothingType>
    <SmoothingLimit>0.01</SmoothingLimit>
    <SmoothingWeighting>0</SmoothingWeighting>
    <ForestType>0</ForestType>
    <NumberForests>1</NumberForests>
    <HashCodeLastRun>1828137109</HashCodeLastRun>
    <DTMColor>
      <R>0</R>
      <G>100</G>
      <B>0</B>
    </DTMColor>
    <ForestList>
      <ForestRoughness>0.5</ForestRoughness>
      <ForestHeight>20</ForestHeight>
      <ForestPorosity>0.3</ForestPorosity>
      <ForestC1>0</ForestC1>
      <ForestC2>0.005</ForestC2>
      <ForestCellsZ>3</ForestCellsZ>
    </ForestList>
  </DTM>
  <CFD>
    <BorderWidth>0</BorderWidth>
    <HorizontalGridingType>0</HorizontalGridingType>
    <NodesMax>100000</NodesMax>
    <HorizontalResolution>20</HorizontalResolution>
    <RatioAdditiveLengthToResolution>0.5</RatioAdditiveLengthToResolution>
    <CellsZ>20</CellsZ>
    <Height>-999</Height>
    <RefinementFileName />
    <DistributionFactor>0.1</DistributionFactor>
    <Orthogonalize>false</Orthogonalize>
    <RefinementType>0</RefinementType>
    <SimpleRefinementXMin>0</SimpleRefinementXMin>
    <SimpleRefinementXMax>0</SimpleRefinementXMax>
    <SimpleRefinementYMin>0</SimpleRefinementYMin>
    <SimpleRefinementYMax>0</SimpleRefinementYMax>
    <NumberSpacings>16</NumberSpacings>
  </CFD>
  <WindField LastChanged="2013-01-15T09:47:38.8850588+01:00">
    <SectorInputType>1</SectorInputType>
    <MesoProjectName />
    <HeightBoundaryLayer>500</HeightBoundaryLayer>
    <VelocityBoundaryLayer>10</VelocityBoundaryLayer>
    <BoundaryConditionTop>1</BoundaryConditionTop>
    <UseMesoInput>false</UseMesoInput>
    <DoNesting>0</DoNesting>
    <UseInputPreviousRun>false</UseInputPreviousRun>
    <MesoscaleDataFolder>C:\Users\WindSim\Documents\WindSim Projects\Data\Mesoscale\</MesoscaleDataFolder>
    <Solver>1</Solver>
    <Sweep>100</Sweep>
    <ConvergenceWizard>false</ConvergenceWizard>
    <ParallelCores>1</ParallelCores>
    <ParallelSimulationsPerCore>2</ParallelSimulationsPerCore>
    <HeightReducedWindData>200</HeightReducedWindData>
    <HashCodeLastRun>-526553864</HashCodeLastRun>
    <TurbMod>1</TurbMod>
    <MonitoringSpotValueCoordSys>3</MonitoringSpotValueCoordSys>
    <MonitoringSpotValueXpos>25</MonitoringSpotValueXpos>
    <MonitoringSpotValueYpos>25</MonitoringSpotValueYpos>
    <MonitoringFieldValue>12</MonitoringFieldValue>
    <IsCoriolis>false</IsCoriolis>
    <Latitude>45</Latitude>
    <Temperature>0</Temperature>
    <ReferenceTemperature>288</ReferenceTemperature>
    <TemperatureGradient>0</TemperatureGradient>
    <MoninObukhovLength>100</MoninObukhovLength>
    <ReferenceHeight>0</ReferenceHeight>
    <WindspeedInReferenceHeight>0</WindspeedInReferenceHeight>
    <AirDensity>1.225</AirDensity>
    <RadialDistribution>0</RadialDistribution>
    <KESource>0</KESource>
    <RunInBatchMode>false</RunInBatchMode>
    <Sector>270</Sector>
  </WindField>
</ProjectParameters>