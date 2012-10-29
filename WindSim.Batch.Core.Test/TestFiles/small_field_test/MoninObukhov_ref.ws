<?xml version="1.0" standalone="yes"?>
<ProjectParameters xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="ProjectParameters.xsd">
  <WindSim>
    <Version>510</Version>
    <ProjectType>wind_energy_micro</ProjectType>
    <Customer />
    <LicenseHolder>Microsoft</LicenseHolder>
  </WindSim>
  <DTM LastChanged="2012-10-01T10:01:43.8752438+01:00">
    <Type>1</Type>
    <CoordSys>3</CoordSys>
    <XMin>0</XMin>
    <XMax>3000</XMax>
    <YMin>0</YMin>
    <YMax>500</YMax>
    <Elongation>1</Elongation>
    <Roughness>0.03</Roughness>
    <GenerateCFDModel>true</GenerateCFDModel>
    <GenerateVTF>true</GenerateVTF>
    <TextureFile />
    <GenerateGLViewFine>false</GenerateGLViewFine>
    <SmoothingType>2</SmoothingType>
    <SmoothingLimit>0.01</SmoothingLimit>
    <SmoothingWeighting>0</SmoothingWeighting>
    <ForestType>1</ForestType>
    <NumberForests>1</NumberForests>
    <HashCodeLastRun>991094633</HashCodeLastRun>
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
    <HorizontalGridingType>1</HorizontalGridingType>
    <NodesMax>100000</NodesMax>
    <HorizontalResolution>250</HorizontalResolution>
    <RatioAdditiveLengthToResolution>0.5</RatioAdditiveLengthToResolution>
    <CellsZ>4</CellsZ>
    <Height>1500</Height>
    <RefinementFileName />
    <DistributionFactor>0.1</DistributionFactor>
    <Orthogonalize>false</Orthogonalize>
    <RefinementType>1</RefinementType>
    <SimpleRefinementXMin>0</SimpleRefinementXMin>
    <SimpleRefinementXMax>3000</SimpleRefinementXMax>
    <SimpleRefinementYMin>0</SimpleRefinementYMin>
    <SimpleRefinementYMax>500</SimpleRefinementYMax>
    <NumberSpacings>16</NumberSpacings>
  </CFD>
  <WindField LastChanged="2012-10-01T09:54:07.5926978+01:00">
    <SectorInputType>1</SectorInputType>
    <MesoProjectName />
    <HeightBoundaryLayer>500</HeightBoundaryLayer>
    <VelocityBoundaryLayer>10</VelocityBoundaryLayer>
    <BoundaryConditionTop>2</BoundaryConditionTop>
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
    <HashCodeLastRun>-1127829894</HashCodeLastRun>
    <TurbMod>5</TurbMod>
    <MonitoringSpotValueCoordSys>3</MonitoringSpotValueCoordSys>
    <MonitoringSpotValueXpos>1500</MonitoringSpotValueXpos>
    <MonitoringSpotValueYpos>250</MonitoringSpotValueYpos>
    <MonitoringFieldValue>0</MonitoringFieldValue>
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