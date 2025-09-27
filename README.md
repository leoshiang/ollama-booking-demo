# C# 也能玩轉本地 AI 模型：使用 Ollama + Llama 3 打造智慧預約系統

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-5C2D91?logo=dotnet)](https://learn.microsoft.com/aspnet/core)
[![Ollama](https://img.shields.io/badge/Ollama-Local%20LLM-00B894)](https://ollama.com)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](#license)

一個以 .NET 9 + ASP.NET Core MVC 為基礎，串接本機 Ollama（以 Llama 3 為例）進行自然語言理解的示範專案。讓使用者以自然語言描述會議室預約需求，系統將解析意圖與關鍵欄位，輸出乾淨的 JSON，輕鬆銜接後端商業流程。

---

## 目錄
- 簡介
- 功能特色
- 快速開始
- 使用說明
- 設定與環境變數
- 專案結構
- 路線圖
- 貢獻方式
- 授權
- 致謝

---

## 簡介

隨著本地大型語言模型（LLM）生態成熟，透過 Ollama 在開發機輕鬆拉起模型，已成為兼顧隱私、成本與可控性的選擇。本專案示範如何在 C#/.NET 環境裡，以簡潔的服務呼叫流程與合理的提示工程（Prompt Engineering），讓模型穩定輸出結構化 JSON，作為預約系統的解析器。

---

## 功能特色

- 本地推理：透過 Ollama 執行 LLM（例：Llama 3）
- 穩定輸出：以 JSON 格式返回意圖與欄位
- 簡單整合：以 HttpClient 呼叫本地模型 API
- MVC 架構：易於擴充、便於接入真實商業邏輯
- 可延伸：支援查詢、取消、補充資訊等進一步意圖

---

## 快速開始

### 前置需求
- .NET SDK 9.0
- Ollama（請先安裝啟動）
- 已下載對應模型（例如 Llama 3 8B，量化版）