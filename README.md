# C# 也能玩轉本地 AI 模型：使用 Ollama + Llama 3 打造智慧預約系統

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-5C2D91?logo=dotnet)](https://learn.microsoft.com/aspnet/core)
[![Ollama](https://img.shields.io/badge/Ollama-Local%20LLM-00B894)](https://ollama.com)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](#license)

一個以 .NET 9 + ASP.NET Core MVC 為基礎，串接本機 Ollama（以 Llama 3 為例）進行自然語言理解的示範專案。讓使用者以自然語言描述會議室預約需求，系統將解析意圖與關鍵欄位，輸出乾淨的 JSON，輕鬆銜接後端商業流程。

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

## 簡介

隨著本地大型語言模型（LLM）生態成熟，透過 Ollama 在開發機輕鬆拉起模型，已成為兼顧隱私、成本與可控性的選擇。本專案示範如何在 C#/.NET 環境裡，以簡潔的服務呼叫流程與合理的提示工程（Prompt Engineering），讓模型穩定輸出結構化 JSON，作為預約系統的解析器。

## 功能特色

- 本地推理：透過 Ollama 執行 LLM（例：Llama 3）
- 穩定輸出：以 JSON 格式返回意圖與欄位
- 簡單整合：以 HttpClient 呼叫本地模型 API
- MVC 架構：易於擴充、便於接入真實商業邏輯
- 可延伸：支援查詢、取消、補充資訊等進一步意圖

## 快速開始

### 前置需求
- .NET SDK 9.0
- Ollama（請先安裝啟動）
- 已下載對應模型（例如 Llama 3 8B，量化版）

```bash
# bash
ollama run llama3:8b-instruct-q4_K_M
```
### 建置與執行

```bash
# bash

# 1) 還沒有專案時，可建立 MVC 範本（若你是從空資料夾開始）

dotnet new mvc -n OllamaBookingDemo cd OllamaBookingDemo

# 2) 安裝 JSON 套件（若需要）

dotnet add package Newtonsoft.Json

# 3) 執行網站

dotnet run

# 內建 Kestrel 啟動後，瀏覽器造訪列印出的 URL（例如 https://localhost:7123）
```

## 使用說明

在網站的輸入框以自然語言輸入預約需求，例如：
- 幫我預約明天的 Alpha 會議室，從下午兩點開始用一個小時
- 幫我查詢今天 Beta 會議室的預約
- 取消我明天上午在 Gamma 會議室的會議

預期模型會輸出結構化 JSON（範例）：

```json
{ "intent": "book_room", "entities": { "room_name": "Alpha 會議室", "date": "2025-09-28", "start_time": "14:00", "duration_minutes": 60 } }
```

若你想直接測試 Ollama 的聊天介面，可用下列範例請求（請先確保 Ollama 服務執行中）：

```bash
# bash
curl -X POST http://localhost:11434/api/chat -H "Content-Type: application/json" -d '{ "model": "llama3:8b-instruct-q4_K_M", "messages": , "format": "json", "stream": false }'
```

## 設定與環境變數

你可以使用環境變數或設定檔調整以下參數：

- OLLAMA_BASE_URL：預設 http://localhost:11434
- OLLAMA_MODEL：預設 llama3:8b-instruct-q4_K_M
- JSON_OUTPUT_FORMAT：預設 json（確保回傳為合法 JSON）

範例（跨平台 shell）：
```bash
# bash

export OLLAMA_BASE_URL="http://localhost:11434" export OLLAMA_MODEL="llama3:8b-instruct-q4_K_M"
```
或在 appsettings.*.json / 使用者祕密管理器中設置。